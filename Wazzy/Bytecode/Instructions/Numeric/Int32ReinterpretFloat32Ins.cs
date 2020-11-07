namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class Int32ReinterpretFloat32Ins : WASMInstruction
    {
        public Int32ReinterpretFloat32Ins()
            : base(OPCode.Int32ReinterpretFloat32)
        { }
    }
}