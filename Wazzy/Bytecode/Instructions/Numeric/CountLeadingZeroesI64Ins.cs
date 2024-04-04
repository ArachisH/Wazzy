namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class CountLeadingZeroesI64Ins : WASMInstruction
{
    public CountLeadingZeroesI64Ins()
        : base(OPCode.CountLeadingZeroesI64)
    { }
}