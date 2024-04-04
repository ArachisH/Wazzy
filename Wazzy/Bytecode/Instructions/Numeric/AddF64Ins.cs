namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AddF64Ins : WASMInstruction
{
    public AddF64Ins()
        : base(OPCode.AddF64)
    { }
}