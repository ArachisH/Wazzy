namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DivideF32Ins : WASMInstruction
{
    public DivideF32Ins()
        : base(OPCode.DivideF32)
    { }
}