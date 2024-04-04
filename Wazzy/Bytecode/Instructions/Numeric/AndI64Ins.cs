namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AndI64Ins : WASMInstruction
{
    public AndI64Ins()
        : base(OPCode.AndI64)
    { }
}