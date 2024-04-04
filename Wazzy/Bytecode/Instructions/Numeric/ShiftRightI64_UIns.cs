namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ShiftRightI64_UIns : WASMInstruction
{
    public ShiftRightI64_UIns()
        : base(OPCode.ShiftRightI64_U)
    { }
}