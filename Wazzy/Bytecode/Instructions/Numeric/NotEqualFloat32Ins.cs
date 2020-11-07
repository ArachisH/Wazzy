namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class NotEqualFloat32Ins : WASMInstruction
    {
        public NotEqualFloat32Ins()
            : base(OPCode.NotEqualFloat32)
        { }
    }
}