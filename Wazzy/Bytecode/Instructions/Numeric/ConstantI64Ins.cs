using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantI64Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantI64Ins(int constant = 0)
            : base(OPCode.ConstantI64)
        {
            Constant = constant;
        }
        public ConstantI64Ins(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Constant);
        }
    }
}