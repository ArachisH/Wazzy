using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantI64Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantI64Ins(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }
        public ConstantI64Ins(int constant = 0)
            : base(OPCode.ConstantI64)
        {
            Constant = constant;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Constant);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(Constant);
    }
}