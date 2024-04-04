namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class EqualI64Ins : WASMInstruction
{
    public EqualI64Ins()
        : base(OPCode.EqualI64)
    { }
}