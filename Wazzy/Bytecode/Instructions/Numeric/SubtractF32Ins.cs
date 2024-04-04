namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class SubtractF32Ins : WASMInstruction
{
    public SubtractF32Ins()
        : base(OPCode.SubtractF32)
    { }
}