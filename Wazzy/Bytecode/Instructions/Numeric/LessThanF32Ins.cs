namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanF32Ins : WASMInstruction
{
    public LessThanF32Ins()
        : base(OPCode.LessThanF32)
    { }
}