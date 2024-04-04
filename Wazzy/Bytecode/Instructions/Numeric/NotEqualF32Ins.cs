namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class NotEqualF32Ins : WASMInstruction
{
    public NotEqualF32Ins()
        : base(OPCode.NotEqualF32)
    { }
}