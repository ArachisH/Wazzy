namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class EqualF32Ins : WASMInstruction
{
    public EqualF32Ins()
        : base(OPCode.EqualF32)
    { }
}