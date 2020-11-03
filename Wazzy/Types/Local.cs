using System;

using Wazzy.IO;

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

        public override void WriteTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(N);
            output.Write(Type);
        }
    }
}