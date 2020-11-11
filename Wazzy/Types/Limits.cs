using System.Diagnostics;

using Wazzy.IO;

namespace Wazzy.Types
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Limits : WASMType
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public bool HasMaximum { get; set; }

        internal string DebuggerDisplay => $"Min: {Minimum:n0}; Max: {(HasMaximum ? (uint)Maximum : uint.MaxValue):n0}";

        public Limits(ref WASMReader input)
        {
            HasMaximum = input.ReadBoolean();
            Minimum = input.ReadIntLEB128();
            if (HasMaximum)
            {
                Maximum = input.ReadIntLEB128();
            }
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.Write(HasMaximum);
            output.WriteLEB128(Minimum);
            if (HasMaximum)
            {
                output.WriteLEB128(Maximum);
            }
        }

        public override int GetSize()
        {
            int size = 0;
            size += sizeof(byte);
            size += WASMReader.GetLEB128Size(Minimum);
            if (HasMaximum)
                size += WASMReader.GetLEB128Size(Maximum);
            return size;
        }
    }
}