namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DivideI32_UIns : WASMInstruction
{
    public DivideI32_UIns()
        : base(OPCode.DivideI32_U)
    { }
}