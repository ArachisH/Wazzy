namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class EqualZeroI64Ins : WASMInstruction
{
    public EqualZeroI64Ins()
        : base(OPCode.EqualZeroI64)
    { }
}