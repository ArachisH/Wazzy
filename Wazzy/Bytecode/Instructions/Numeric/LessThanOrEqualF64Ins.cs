namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanOrEqualF64Ins : WASMInstruction
{
    public LessThanOrEqualF64Ins()
        : base(OPCode.LessThanOrEqualF64)
    { }
}