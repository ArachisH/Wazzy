namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MaxF64Ins : WASMInstruction
{
    public MaxF64Ins()
        : base(OPCode.MaxF64)
    { }
}