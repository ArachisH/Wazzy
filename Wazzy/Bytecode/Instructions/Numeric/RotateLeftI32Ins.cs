namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class RotateLeftI32Ins : WASMInstruction
{
    public RotateLeftI32Ins()
        : base(OPCode.RotateLeftI32)
    { }
}