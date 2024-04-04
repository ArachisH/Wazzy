namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ShiftLeftI32Ins : WASMInstruction
{
    public ShiftLeftI32Ins()
         : base(OPCode.ShiftLeftI32)
    { }
}