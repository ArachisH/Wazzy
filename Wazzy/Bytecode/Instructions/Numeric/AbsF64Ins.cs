namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AbsF64Ins : WASMInstruction
{
    public AbsF64Ins()
        : base(OPCode.AbsF64)
    { }
}