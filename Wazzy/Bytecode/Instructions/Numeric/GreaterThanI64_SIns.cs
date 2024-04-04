namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanI64_SIns : WASMInstruction
{
    public GreaterThanI64_SIns()
        : base(OPCode.GreaterThanI64_S)
    { }
}