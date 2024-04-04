namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class NegateF32Ins : WASMInstruction
{
    public NegateF32Ins()
        : base(OPCode.NegateF32)
    { }
}