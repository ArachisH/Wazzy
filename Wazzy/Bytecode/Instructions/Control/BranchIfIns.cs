using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BranchIfIns : WASMInstruction
    {
        public int LabelIndex { get; set; }

        public BranchIfIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }
        public BranchIfIns(int labelIndex = 0)
            : base(OPCode.BranchIf)
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