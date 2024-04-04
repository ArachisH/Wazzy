namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class RemainderI64_UIns : WASMInstruction
{
    public RemainderI64_UIns()
        : base(OPCode.RemainderI64_U)
    { }
}