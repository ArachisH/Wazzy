namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MultiplyF32Ins : WASMInstruction
{
    public MultiplyF32Ins()
        : base(OPCode.MultiplyF32)
    { }
}