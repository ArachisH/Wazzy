namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ExtendSignedI32IntoI64Ins : WASMInstruction
    {
        public ExtendSignedI32IntoI64Ins()
            : base(OPCode.ExtendSignedI32IntoI64)
        { }
    }
}