namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ShiftRightI32_SIns : WASMInstruction
{
    public ShiftRightI32_SIns()
        : base(OPCode.ShiftRightI32_S)
    { }
}