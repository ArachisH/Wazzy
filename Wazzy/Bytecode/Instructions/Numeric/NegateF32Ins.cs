namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class NegateF32Ins : WASMInstruction
    {
        public NegateF32Ins()
            : base(OPCode.NegateF32)
        { }
    }
}