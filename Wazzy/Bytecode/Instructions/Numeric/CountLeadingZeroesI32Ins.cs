namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class CountLeadingZeroesI32Ins : WASMInstruction
{
    public CountLeadingZeroesI32Ins()
        : base(OPCode.CountLeadingZeroesI32)
    { }
}