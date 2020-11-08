namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class WrapI64IntoI32Ins : WASMInstruction
    {
        public WrapI64IntoI32Ins()
            : base(OPCode.WrapI64IntoI32)
        { }
    }
}