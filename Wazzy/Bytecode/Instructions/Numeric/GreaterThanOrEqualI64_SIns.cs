namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanOrEqualI64_SIns : WASMInstruction
{
    public GreaterThanOrEqualI64_SIns()
        : base(OPCode.GreaterThanOrEqualI64_S)
    { }
}