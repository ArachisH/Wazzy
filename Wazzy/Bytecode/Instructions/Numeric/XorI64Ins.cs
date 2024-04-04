namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class XorI64Ins : WASMInstruction
{
    public XorI64Ins()
        : base(OPCode.XorI64)
    { }
}