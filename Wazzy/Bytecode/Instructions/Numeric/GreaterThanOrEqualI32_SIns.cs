namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanOrEqualI32_SIns : WASMInstruction
{
    public GreaterThanOrEqualI32_SIns()
        : base(OPCode.GreaterThanOrEqualI32_S)
    { }
}