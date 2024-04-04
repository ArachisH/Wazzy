namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AddF32Ins : WASMInstruction
{
    public AddF32Ins()
        : base(OPCode.AddF32)
    { }
}