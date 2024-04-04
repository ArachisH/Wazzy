namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanF64Ins : WASMInstruction
{
    public GreaterThanF64Ins()
        : base(OPCode.GreaterThanF64)
    { }
}