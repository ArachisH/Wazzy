namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AddI64Ins : WASMInstruction
{
    public AddI64Ins()
        : base(OPCode.AddI64)
    { }
}