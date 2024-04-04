namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MultiplyI64Ins : WASMInstruction
{
    public MultiplyI64Ins()
        : base(OPCode.MultiplyI64)
    { }
}