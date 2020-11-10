using System;
using System.IO;
using System.Text;

namespace Wazzy.IO
{
    public class WASMWriter : BinaryWriter
    {
        public int Position
        {
            get => (int)BaseStream.Position;
            set => BaseStream.Position = value;
        }
        public int Length => (int)BaseStream.Length;

        public WASMWriter()
            : base(new MemoryStream())
        { }
        public WASMWriter(Stream output)
            : base(output)
        { }
        public WASMWriter(Stream output, Encoding encoding)
            : base(output, encoding)
        { }
        public WASMWriter(Stream output, Encoding encoding, bool leaveOpen)
            : base(output, encoding, leaveOpen)
        { }

        public void Write(Type valueType)
        {
            switch (Type.GetTypeCode(valueType))
            {
                case TypeCode.Int32: Write((byte)0x7F); break;
                case TypeCode.Int64: Write((byte)0x7E); break;
                case TypeCode.Single: Write((byte)0x7D); break;
                case TypeCode.Double: Write((byte)0x7C); break;
                default: break;
            }
        }

        public new void Write7BitEncodedInt(int value)
        {
            value |= 0;
            while (true)
            {
                var b = (byte)(value & 0x7F);
                value >>= 7;

                if ((value == 0 && (b & 0x40) == 0) || (value == -1 && (b & 0x40) != 0))
                {
                    Write(b);
                    return;
                }
                Write((byte)(b | 0x80));
            }
        }
        public void Write7BitEncodedString(string value)
        {
            byte[] valueData = Encoding.UTF8.GetBytes(value);
            Write7BitEncodedInt(valueData.Length);
            Write(valueData);
        }
    }
}