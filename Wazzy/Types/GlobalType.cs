using System;

using Wazzy.IO;

namespace Wazzy.Types
{
    public class GlobalType : WASMType
    {
        public Type ValueType { get; set; }
        public bool IsReadOnly { get; set; }

        public GlobalType(WASMModule module)
        {
            ValueType = module.Input.ReadValueType();
            IsReadOnly = !module.Input.ReadBoolean();
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write(ValueType);
            output.Write(!IsReadOnly); // False|0x00 = const
        }
    }
}