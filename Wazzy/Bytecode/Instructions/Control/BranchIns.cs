using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BranchIns : WASMInstruction
    {
        public int LabelIndex { get; set; }

        public BranchIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }
        public BranchIns(int labelIndex = 0)
            : base(OPCode.Branch)
        {
            LabelIndex = labelIndex;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(LabelIndex);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(LabelIndex);
    }
}