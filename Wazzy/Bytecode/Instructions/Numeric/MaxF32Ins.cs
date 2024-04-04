namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MaxF32Ins : WASMInstruction
{
    public MaxF32Ins()
        : base(OPCode.MaxF32)
    { }
}