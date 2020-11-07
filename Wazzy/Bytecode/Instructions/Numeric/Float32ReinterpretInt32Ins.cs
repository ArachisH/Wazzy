namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class Float32ReinterpretInt32Ins : WASMInstruction
    {
        public Float32ReinterpretInt32Ins()
            : base(OPCode.Float32ReinterpretInt32)
        { }
    }
}