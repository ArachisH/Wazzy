namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanF64Ins : WASMInstruction
{
    public LessThanF64Ins()
        : base(OPCode.LessThanF64)
    { }
}