namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class FloorF32Ins : WASMInstruction
{
    public FloorF32Ins()
        : base(OPCode.FloorF32)
    { }
}