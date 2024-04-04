namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanI32_UIns : WASMInstruction
{
    public LessThanI32_UIns()
        : base(OPCode.LessThanI32_U)
    { }
}