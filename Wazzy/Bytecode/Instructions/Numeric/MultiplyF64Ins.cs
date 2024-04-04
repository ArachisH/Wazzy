namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MultiplyF64Ins : WASMInstruction
{
    public MultiplyF64Ins()
        : base(OPCode.MultiplyF64)
    { }
}