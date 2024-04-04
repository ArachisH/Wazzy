namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class NotEqualF64Ins : WASMInstruction
{
    public NotEqualF64Ins()
        : base(OPCode.NotEqualF64)
    { }
}