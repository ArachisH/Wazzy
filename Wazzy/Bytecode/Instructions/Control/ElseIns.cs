namespace Wazzy.Bytecode.Instructions.Control
{
    public class ElseIns : WASMInstruction
    {
        public ElseIns()
            : base(OPCode.Else)
        { }
    }
}