namespace Wazzy.Bytecode.Instructions.Parametric;

public sealed class SelectIns : WASMInstruction
{
    public SelectIns()
        : base(OPCode.Select)
    { }
}