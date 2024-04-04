namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanI64_SIns : WASMInstruction
{
    public LessThanI64_SIns()
        : base(OPCode.LessThanI64_S)
    { }
}