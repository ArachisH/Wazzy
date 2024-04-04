namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class OrI32Ins : WASMInstruction
{
    public OrI32Ins()
        : base(OPCode.OrI32)
    { }
}