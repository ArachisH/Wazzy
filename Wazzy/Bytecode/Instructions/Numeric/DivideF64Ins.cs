namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DivideF64Ins : WASMInstruction
{
    public DivideF64Ins()
        : base(OPCode.DivideF64)
    { }
}