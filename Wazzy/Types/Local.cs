using System;

using Wazzy.IO;

namespace Wazzy.Types
{
    public class Local : WASMType
    {
        private readonly int _typeIndex = -1;

        public int Rank { get; }
        public Type Type { get; }

        public Local(ref WASMReader input)
        {
            Rank = input.ReadIntLEB128();
            _typeIndex = input.ReadIntLEB128();
            if (IsSupportedType(_typeIndex))
            {
                Type = GetType(_typeIndex);
            }
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.WriteLEB128(Rank);
            output.WriteLEB128(_typeIndex);
        }

        public override int GetSize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Rank);
            size += WASMReader.GetLEB128Size(_typeIndex);
            return size;
        }
    }
}