namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ShiftRightI32_UIns : WASMInstruction
{
    public ShiftRightI32_UIns()
        : base(OPCode.ShiftRightI32_U)
    { }
}