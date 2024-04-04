namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanI32_SIns : WASMInstruction
{
    public GreaterThanI32_SIns()
        : base(OPCode.GreaterThanI32_S)
    { }
}