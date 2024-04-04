namespace Wazzy.Bytecode.Instructions.Control;

public sealed class ReturnIns : WASMInstruction
{
    public ReturnIns()
        : base(OPCode.Return)
    { }
}