namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class EqualF64Ins : WASMInstruction
{
    public EqualF64Ins()
        : base(OPCode.EqualF64)
    { }
}