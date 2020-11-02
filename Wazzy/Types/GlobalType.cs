using System;

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
    }
}