namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ReinterpretI64IntoF32Ins : WASMInstruction
    {
        public ReinterpretI64IntoF32Ins()
            : base(OPCode.ReinterpretI64IntoF32)
        { }
    }
}