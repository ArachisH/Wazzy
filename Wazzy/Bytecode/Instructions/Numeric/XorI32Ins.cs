namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class XorI32Ins : WASMInstruction
{
    public XorI32Ins()
        : base(OPCode.XorI32)
    { }
}