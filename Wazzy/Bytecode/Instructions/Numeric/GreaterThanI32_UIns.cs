namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanI32_UIns : WASMInstruction
{
    public GreaterThanI32_UIns()
        : base(OPCode.GreaterThanI32_U)
    { }
}