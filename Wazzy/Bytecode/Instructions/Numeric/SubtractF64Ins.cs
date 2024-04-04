namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class SubtractF64Ins : WASMInstruction
{
    public SubtractF64Ins()
        : base(OPCode.SubtractF64)
    { }
}