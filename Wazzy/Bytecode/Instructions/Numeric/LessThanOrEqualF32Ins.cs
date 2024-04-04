namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanOrEqualF32Ins : WASMInstruction
{
    public LessThanOrEqualF32Ins()
        : base(OPCode.LessThanOrEqualF32)
    { }
}