namespace Wazzy.Bytecode.Instructions.Control
{
    public class EndIns : WASMInstruction
    {
        public EndIns()
            : base(OPCode.End)
        { }
    }
}