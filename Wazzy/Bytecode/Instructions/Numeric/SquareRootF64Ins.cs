namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class SquareRootF64Ins : WASMInstruction
{
    public SquareRootF64Ins()
        : base(OPCode.SquareRootF64)
    { }
}