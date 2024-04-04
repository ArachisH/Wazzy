namespace Wazzy.Bytecode.Instructions.Control;

public sealed class EndIns : WASMInstruction
{
    public EndIns()
        : base(OPCode.End)
    { }
}