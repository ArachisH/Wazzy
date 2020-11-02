using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Wazzy.Types;
using Wazzy.Bytecode;

namespace Wazzy.IO
{
    public class WASMReader : BinaryReader
    {
        public int Position
        {
            get => (int)BaseStream.Position;
            set => BaseStream.Position = value;
        }
        public int Length => (int)BaseStream.Length;

        public WASMReader(byte[] data)
            : base(new MemoryStream(data))
        { }
        public WASMReader(Stream input)
            : base(input)
        { }
        public WASMReader(Stream input, bool leaveOpen)
            : base(input, Encoding.UTF8, leaveOpen)
        { }

        public List<WASMInstruction> ReadExpression()
        {
            var expression = new List<WASMInstruction>(3);
            do expression.Add(WASMInstruction.Create(this));
            while (expression[^1].OP != OPCode.End);
            return expression;
        }
        public Type ReadValueType() => WASMType.GetType(ReadByte());
        new public int Read7BitEncodedInt() => base.Read7BitEncodedInt();
        public string Read7BitEncodedString() => ReadString(Read7BitEncodedInt());
        public string ReadString(int length) => Encoding.UTF8.GetString(ReadBytes(length));
        public byte[] ReadBytesUntil(int bufferSize, int bufferIncrementSize, byte endMark = 0x00)
        {
            byte[] data = null;
            var dataShell = new byte[bufferSize];
            for (int i = 0; i < dataShell.Length; i++)
            {
                dataShell[i] = ReadByte();
                if (dataShell[i] == endMark)
                {
                    data = new byte[i + 1];
                    Buffer.BlockCopy(dataShell, 0, data, 0, data.Length);
                    return data;
                }
                else if (i == dataShell.Length - 1)
                {
                    var tempInstructions = new byte[dataShell.Length + bufferIncrementSize]; // Keep allocating bytes every time we run out of room.
                    Buffer.BlockCopy(dataShell, 0, tempInstructions, 0, dataShell.Length);
                    dataShell = tempInstructions;
                }
            }
            return data;
        }

        public static int Get7BitEncodedIntSize(int value)
        {
            int size = 1;
            var uValue = (uint)value;
            while (uValue >= 0x80)
            {
                size++;
                uValue >>= 7;
            }
            return size;
        }
    }
}