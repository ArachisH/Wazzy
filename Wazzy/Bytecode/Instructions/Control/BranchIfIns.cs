using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BranchIfIns : WASMInstruction
    {
        public int LabelIndex { get; set; }

        public BranchIfIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }
        public BranchIfIns(int labelIndex = 0)
            : base(OPCode.BranchIf)
        {
            LabelIndex = labelIndex;
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(LabelIndex);
        }
    }
}