namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MultiplyI32Ins : WASMInstruction
{
    public MultiplyI32Ins()
        : base(OPCode.MultiplyI32)
    { }
}