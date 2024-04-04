using System.Text;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using Wazzy.Types;
using Wazzy.Bytecode;

namespace Wazzy.IO;

public ref struct WASMReader
{
    private readonly ReadOnlySpan<byte> _data;

    public int Position { get; set; }

    public readonly int Length => _data.Length;
    public readonly bool IsDataAvailable => Position < _data.Length;

    public WASMReader(ReadOnlySpan<byte> data)
    {
        _data = data;

        Position = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte ReadByte() => _data[Position++];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<byte> ReadBytes(int count)
    {
        ReadOnlySpan<byte> data = _data.Slice(Position, count);
        Position += count;
        return data;
    }

    public void ReadBytes(Span<byte> buffer)
    {
        _data.Slice(Position, buffer.Length).CopyTo(buffer);
        Position += buffer.Length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool ReadBoolean() => _data[Position++] == 1;

    public int ReadInt32()
    {
        int value = MemoryMarshal.Read<int>(_data.Slice(Position));
        Position += sizeof(int);
        return value;
    }
    public uint ReadUInt32()
    {
        uint value = MemoryMarshal.Read<uint>(_data.Slice(Position));
        Position += sizeof(uint);
        return value;
    }

    public float ReadSingle()
    {
        float value = MemoryMarshal.Read<float>(_data.Slice(Position));
        Position += sizeof(float);
        return value;
    }
    public double ReadDouble()
    {
        double value = MemoryMarshal.Read<double>(_data.Slice(Position));
        Position += sizeof(double);
        return value;
    }

    public uint ReadIntULEB128()
    {
        uint result = 0;

        const int MaxRead = 5;
        for (int shift = 0; shift < MaxRead * 7; shift += 7)
        {
            byte b = ReadByte();
            result |= (b & 0x7Fu) << shift;

            if (b <= 0x7Fu)
                return result;
        }
        throw new OverflowException();
    }
    public ulong ReadLongULEB128()
    {
        ulong result = 0;

        const int MaxRead = 10;
        for (int shift = 0; shift < MaxRead * 7; shift += 7)
        {
            byte b = ReadByte();
            result |= (b & 0x7FUL) << shift;

            if (b <= 0x7Fu)
                return result;
        }
        throw new OverflowException();
    }

    public int ReadIntLEB128()
    {
        byte b;
        int shift = 0;
        int result = 0;
        do
        {
            b = ReadByte();

            if (shift == 35 && b != 0 && b != 0x7F)
                throw new OverflowException();

            result |= (b & 0x7F) << shift;
            shift += 7;
        } while ((b & 0x80) != 0);

        if (shift < 32 && (b & 0x40) != 0)
            result |= -1 << shift; //sign extend

        return result;
    }
    public long ReadLongLEB128()
    {
        byte b;
        int shift = 0;
        long result = 0;
        do
        {
            b = ReadByte();

            if (shift == 63 && b != 0 && b != 0x7F)
                throw new OverflowException();

            result |= (b & 0x7FL) << shift;
            shift += 7;
        } while ((b & 0x80) != 0);

        if (shift < 64 && (b & 0x40) != 0)
            result |= -1L << shift; //sign extend

        return result;
    }

    /// <summary>
    /// Return the number of bytes required to encode signed integer using LEB128 encoding.
    /// </summary>
    public static int GetLEB128Size(long value)
    {
        // Same as unsigned size calculation but we have to account for the sign bit
        value ^= value >> 63;
        int x = 1 + 6 + 64 - BitOperations.LeadingZeroCount((ulong)value | 1UL);
        return (x * 37) >> 8;
    }
    /// <summary>
    /// Return the number of bytes required to encode unsigned integer using LEB128 encoding.
    /// </summary>
    public static int GetULEB128Size(ulong value)
    {
        // Black magic provided to us kindly by AOSP source <3, modified for 64-bit values

        // bits_to_encode = (data != 0) ? 64 - CLZ(x) : 1  // 64 - CLZ(data | 1)
        // bytes = ceil(bits_to_encode / 7.0);             // (6 + bits_to_encode) / 7
        int x = 6 + 64 - BitOperations.LeadingZeroCount(value | 1UL);
        // Division by 7 is done by (x * 37) >> 8 where 37 = ceil(256 / 7).
        // This works for 0 <= x < 256 / (7 * 37 - 256), i.e. 0 <= x <= 85.
        return (x * 37) >> 8;
    }
    public static int GetULEB128Size(string name)
    {
        int nameSize = Encoding.UTF8.GetByteCount(name);
        return GetULEB128Size((uint)nameSize) + nameSize;
    }

    /// <summary>
    /// Returns a ULEB128 length-prefixed UTF8 string.
    /// </summary>
    public string ReadString() => ReadString((int)ReadIntULEB128());
    public string ReadString(int length) => Encoding.UTF8.GetString(ReadBytes(length));

    public Type ReadValueType() => WASMType.GetValueType(ReadByte());

    public List<WASMInstruction> ReadExpression(IFunctionOffsetProvider functionOffsetProvider, bool isBreakingOnElseInstruction = false)
    {
        var expression = new List<WASMInstruction>(3);
        while (Position < Length)
        {
            var op = (OPCode)ReadByte();
            var instruction = WASMInstruction.Create(ref this, op, functionOffsetProvider);

            expression.Add(instruction);
            if (op == OPCode.End || (isBreakingOnElseInstruction && op == OPCode.Else)) break;
        }
        return expression;
    }
    public List<WASMInstruction> ReadExpression(bool isBreakingOnElseInstruction = false) => ReadExpression(null, isBreakingOnElseInstruction);
}