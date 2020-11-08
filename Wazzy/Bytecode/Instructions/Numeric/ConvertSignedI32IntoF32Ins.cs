namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConvertSignedI32IntoF32Ins : WASMInstruction
    {
        public ConvertSignedI32IntoF32Ins()
            : base(OPCode.ConvertSignedI32IntoF32)
        { }
    }
}