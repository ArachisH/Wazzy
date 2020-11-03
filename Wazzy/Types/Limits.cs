using System.Diagnostics;

using Wazzy.IO;

namespace Wazzy.Types
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Limits : WASMType
    {
        public int Minimum { get; set; }
        public int Maxiumum { get; set; }
        public bool HasMaximum { get; set; }

        internal string DebuggerDisplay => $"Min: {Minimum:n0}; Max: {(HasMaximum ? (uint)Maxiumum : uint.MaxValue):n0}";

        public Limits(WASMModule module)
        {
            HasMaximum = module.Input.ReadBoolean();
            Minimum = module.Input.Read7BitEncodedInt();
            if (HasMaximum)
            {
                Maxiumum = module.Input.Read7BitEncodedInt();
            }
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write(HasMaximum);
            output.Write7BitEncodedInt(Minimum);
            if (HasMaximum)
            {
                output.Write7BitEncodedInt(Maxiumum);
            }
        }
    }
}