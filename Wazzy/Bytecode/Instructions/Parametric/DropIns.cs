namespace Wazzy.Bytecode.Instructions.Parametric
{
    public class DropIns : WASMInstruction
    {
        public DropIns()
            : base(OPCode.Drop)
        { }
    }
}