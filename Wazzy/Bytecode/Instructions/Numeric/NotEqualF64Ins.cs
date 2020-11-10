namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class NotEqualF64Ins : WASMInstruction
    {
        public NotEqualF64Ins()
            : base(OPCode.NotEqualF64)
        { }
    }
}