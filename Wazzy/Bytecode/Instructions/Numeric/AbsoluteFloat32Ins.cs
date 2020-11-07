namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class AbsoluteFloat32Ins : WASMInstruction
    {
        public AbsoluteFloat32Ins()
            : base(OPCode.AbsoluteFloat32)
        { }
    }
}