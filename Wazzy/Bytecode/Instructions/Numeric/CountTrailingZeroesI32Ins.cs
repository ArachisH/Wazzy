namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class CountTrailingZeroesI32Ins : WASMInstruction
{
    public CountTrailingZeroesI32Ins()
        : base(OPCode.CountTrailingZeroesI32)
    { }
}