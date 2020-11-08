namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ShiftLeftI64Ins : WASMInstruction
    {
        public ShiftLeftI64Ins()
            : base(OPCode.ShiftLeftI64)
        { }
    }
}