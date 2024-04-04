namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanOrEqualI64_UIns : WASMInstruction
{
    public GreaterThanOrEqualI64_UIns()
        : base(OPCode.GreaterThanOrEqualI64_U)
    { }
}