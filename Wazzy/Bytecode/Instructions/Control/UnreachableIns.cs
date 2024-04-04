namespace Wazzy.Bytecode.Instructions.Control;

public sealed class UnreachableIns : WASMInstruction
{
    public UnreachableIns()
        : base(OPCode.Unreachable)
    { }
}