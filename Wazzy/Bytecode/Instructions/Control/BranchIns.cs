using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BranchIns : WASMInstruction
    {
        public int LabelIndex { get; set; }

        public BranchIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }
        public BranchIns(int labelIndex = 0)
            : base(OPCode.Branch)
        {
            LabelIndex = labelIndex;
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(LabelIndex);
        }
    }
}