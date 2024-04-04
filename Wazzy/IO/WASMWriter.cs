using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using Wazzy.Types;

namespace Wazzy.IO;

public ref struct WASMWriter
{
    private int _position;
    private readonly Span<byte> _data;

    public WASMWriter(Span<byte> data)
    {
        _data = data;
        _position = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(byte value) => _data[_position++] = value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(bool value) => _data[_position++] = Unsafe.As<bool, byte>(ref value);

    public void Write(int value)
    {
        MemoryMarshal.Write(_data.Slice(_position), ref value);
        _position += sizeof(int);
    }
    public void Write(uint value)
    {
        MemoryMarshal.Write(_data.Slice(_position), ref value);
        _position += sizeof(uint);
    }
    public void Write(float value)
    {
        MemoryMarshal.Write(_data.Slice(_position), ref value);
        _position += sizeof(float);
    }
    public void Write(double value)
    {
        MemoryMarshal.Write(_data.Slice(_position), ref value);
        _position += sizeof(double);
    }
    public void Write(ReadOnlySpan<byte> value)
    {
        value.CopyTo(_data.Slice(_position));
        _position += value.Length;
    }
    public void Write(Type valueType) => Write(WASMType.GetValueTypeId(valueType));

    public void WriteLEB128(long value)
    {
        bool done;
        do
        {
            byte b = (byte)value;
            value >>= 6; //Keep the sign-bit
            if (done = (value == 0 || value == -1))
            {
                Write((byte)(b & 0x7F));
            }
            else
            {
                value >>= 1; //Remove sign-bit
                Write((byte)(b | ~0x7Fu));
            }
        }
        while (!done);
    }
    public void WriteULEB128(ulong value)
    {
        do Write((byte)((value & 0x7FUL) | ~0x7FU));
        while ((value >>= 7) != 0);

        _data[_position - 1] &= 0x7F;
    }

    public void WriteString(ReadOnlySpan<char> value)
    {
        WriteULEB128((uint)value.Length);

        int len = Encoding.UTF8.GetBytes(value, _data.Slice(_position));
        _position += len;
    }
}