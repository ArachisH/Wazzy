namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class FloorF64Ins : WASMInstruction
{
    public FloorF64Ins()
        : base(OPCode.FloorF64)
    { }
}