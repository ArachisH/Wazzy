namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class SubtractI64Ins : WASMInstruction
{
    public SubtractI64Ins()
        : base(OPCode.SubtractI64)
    { }
}