namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class RemainderI64_SIns : WASMInstruction
{
    public RemainderI64_SIns()
        : base(OPCode.RemainderI64_S)
    { }
}