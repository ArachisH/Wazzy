using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BranchIns : WASMInstruction
    {
        public int LabelIndex { get; set; }

        public BranchIns(int labelIndex)
            : base(OPCode.Branch)
        {
            LabelIndex = labelIndex;
        }
        public BranchIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(LabelIndex);
        }
    }
}