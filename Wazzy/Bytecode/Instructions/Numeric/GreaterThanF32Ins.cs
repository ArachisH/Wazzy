namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanF32Ins : WASMInstruction
{
    public GreaterThanF32Ins()
        : base(OPCode.GreaterThanF32)
    { }
}