namespace Wazzy.Bytecode.Instructions
{
    public class EndIns : WASMInstruction
    {
        public EndIns()
            : base(OPCode.End)
        { }
    }
}