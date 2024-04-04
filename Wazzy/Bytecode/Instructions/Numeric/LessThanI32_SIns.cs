namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanI32_SIns : WASMInstruction
{
    public LessThanI32_SIns()
        : base(OPCode.LessThanI32_S)
    { }
}