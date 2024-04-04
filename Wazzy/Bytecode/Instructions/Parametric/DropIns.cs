namespace Wazzy.Bytecode.Instructions.Parametric;

public sealed class DropIns : WASMInstruction
{
    public DropIns()
        : base(OPCode.Drop)
    { }
}