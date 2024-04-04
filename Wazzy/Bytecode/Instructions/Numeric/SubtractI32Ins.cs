namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class SubtractI32Ins : WASMInstruction
{
    public SubtractI32Ins()
        : base(OPCode.SubtractI32)
    { }
}