namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class PromoteF32IntoF64Ins : WASMInstruction
    {
        public PromoteF32IntoF64Ins()
            : base(OPCode.PromoteF32IntoF64)
        { }
    }
}