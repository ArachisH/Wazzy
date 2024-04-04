namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class EqualI32Ins : WASMInstruction
{
    public EqualI32Ins()
        : base(OPCode.EqualI32)
    { }
}