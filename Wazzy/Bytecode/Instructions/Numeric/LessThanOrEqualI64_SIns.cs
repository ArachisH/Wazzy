namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanOrEqualI64_SIns : WASMInstruction
{
    public LessThanOrEqualI64_SIns()
        : base(OPCode.LessThanOrEqualI64_S)
    { }
}