namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanOrEqualF64Ins : WASMInstruction
{
    public GreaterThanOrEqualF64Ins()
        : base(OPCode.GreaterThanOrEqualF64)
    { }
}