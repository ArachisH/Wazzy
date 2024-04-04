namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanOrEqualF32Ins : WASMInstruction
{
    public GreaterThanOrEqualF32Ins()
        : base(OPCode.GreaterThanOrEqualF32)
    { }
}