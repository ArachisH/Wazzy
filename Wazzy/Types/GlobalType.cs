using System;

using Wazzy.IO;

namespace Wazzy.Types
{
    public class GlobalType : WASMType
    {
        public Type ValueType { get; set; }
        public bool IsReadOnly { get; set; }

        public GlobalType(ref WASMReader input)
        {
            ValueType = input.ReadValueType();
            IsReadOnly = !input.ReadBoolean();
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.Write(ValueType);
            output.Write(!IsReadOnly); // False|0x00 = const
        }

        public override int GetSize()
        {
            int size = 0;
            size += sizeof(byte);
            size += sizeof(byte);
            return size;
        }
    }
}