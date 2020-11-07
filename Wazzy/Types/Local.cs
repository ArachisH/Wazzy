using System;

using Wazzy.IO;

namespace Wazzy.Types
{
    public class Local : WASMType
    {
        private readonly int _typeIndex = -1;

        public int Rank { get; }
        public Type Type { get; }

        public Local(WASMModule module)
        {
            Rank = module.Input.Read7BitEncodedInt();
            _typeIndex = module.Input.Read7BitEncodedInt();
            if (IsSupportedType(_typeIndex))
            {
                Type = GetType(_typeIndex);
            }
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Rank);
            output.Write7BitEncodedInt(_typeIndex);
        }
    }
}