namespace Wazzy.Bytecode.Instructions.Control;

public sealed class NopIns : WASMInstruction
{
    public NopIns()
        : base(OPCode.Nop)
    { }
}