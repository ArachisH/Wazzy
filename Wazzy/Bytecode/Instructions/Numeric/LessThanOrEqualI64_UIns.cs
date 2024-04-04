namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanOrEqualI64_UIns : WASMInstruction
{
    public LessThanOrEqualI64_UIns()
        : base(OPCode.LessThanOrEqualI64_U)
    { }
}