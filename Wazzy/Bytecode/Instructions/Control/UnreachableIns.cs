namespace Wazzy.Bytecode.Instructions.Control
{
    public class UnreachableIns : WASMInstruction
    {
        public UnreachableIns()
            : base(OPCode.Unreachable)
        { }
    }
}