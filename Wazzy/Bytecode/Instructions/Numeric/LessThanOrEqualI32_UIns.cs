namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanOrEqualI32_UIns : WASMInstruction
{
    public LessThanOrEqualI32_UIns()
        : base(OPCode.LessThanOrEqualI32_U)
    { }
}