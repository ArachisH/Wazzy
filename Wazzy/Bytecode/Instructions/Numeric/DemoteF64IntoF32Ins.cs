namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DemoteF64IntoF32Ins : WASMInstruction
{
    public DemoteF64IntoF32Ins()
        : base(OPCode.DemoteF64IntoF32)
    { }
}