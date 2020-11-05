namespace Wazzy.Bytecode.Instructions.Control
{
    public class NopIns : WASMInstruction
    {
        public NopIns()
            : base(OPCode.Nop)
        { }
    }
}