namespace Wazzy.Bytecode.Instructions.Parametric
{
    public class SelectIns : WASMInstruction
    {
        public SelectIns()
            : base(OPCode.Select)
        { }
    }
}