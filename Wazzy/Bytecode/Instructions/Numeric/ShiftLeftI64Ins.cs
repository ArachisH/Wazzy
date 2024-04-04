namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ShiftLeftI64Ins : WASMInstruction
{
    public ShiftLeftI64Ins()
        : base(OPCode.ShiftLeftI64)
    { }
}