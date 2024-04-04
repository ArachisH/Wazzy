namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class NotEqualI32Ins : WASMInstruction
{
    public NotEqualI32Ins()
        : base(OPCode.NotEqualI32)
    { }
}