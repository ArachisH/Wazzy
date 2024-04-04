namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AbsoluteF32Ins : WASMInstruction
{
    public AbsoluteF32Ins()
        : base(OPCode.AbsoluteF32)
    { }
}