using System;

namespace Wazzy.Types
{
    public class Local :  WASMType
    {
        public int N { get; }
        public Type Type { get; }

        public Local(WASMModule module)
        {
            N = module.Input.Read7BitEncodedInt();
            Type = module.Input.ReadValueType();
        }
    }
}