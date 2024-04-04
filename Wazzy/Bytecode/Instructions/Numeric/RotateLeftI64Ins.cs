namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class RotateLeftI64Ins : WASMInstruction
{
    public RotateLeftI64Ins()
        : base(OPCode.RotateLeftI64)
    { }
}