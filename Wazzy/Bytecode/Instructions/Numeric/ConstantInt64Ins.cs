using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantInt64Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantInt64Ins(int constant = 0)
            : base(OPCode.ConstantInt64)
        {
            Constant = constant;
        }
        public ConstantInt64Ins(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Constant);
        }
    }
}