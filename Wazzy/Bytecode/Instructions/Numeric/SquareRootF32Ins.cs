namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class SquareRootF32Ins : WASMInstruction
{
    public SquareRootF32Ins()
        : base(OPCode.SquareRootF32)
    { }
}