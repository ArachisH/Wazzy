namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanOrEqualI32_UIns : WASMInstruction
{
    public GreaterThanOrEqualI32_UIns()
        : base(OPCode.GreaterThanOrEqualI32_U)
    { }
}