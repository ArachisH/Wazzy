namespace Wazzy.Bytecode.Instructions.Control
{
    public class ReturnIns : WASMInstruction
    {
        public ReturnIns()
            : base(OPCode.Return)
        { }
    }
}