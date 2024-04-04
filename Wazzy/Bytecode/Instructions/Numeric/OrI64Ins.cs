namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class OrI64Ins : WASMInstruction
{
    public OrI64Ins()
        : base(OPCode.OrI64)
    { }
}