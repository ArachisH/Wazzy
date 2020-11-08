namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ExtendUnsignedI32IntoI64Ins : WASMInstruction
    {
        public ExtendUnsignedI32IntoI64Ins()
            : base(OPCode.ExtendUnsignedI32IntoI64)
        { }
    }
}