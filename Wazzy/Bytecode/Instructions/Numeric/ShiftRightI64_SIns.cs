namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ShiftRightI64_SIns : WASMInstruction
{
    public ShiftRightI64_SIns()
        : base(OPCode.ShiftRightI64_S)
    { }
}