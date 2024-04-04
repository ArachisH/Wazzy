namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class RemainderI32_SIns : WASMInstruction
{
    public RemainderI32_SIns()
        : base(OPCode.RemainderI32_S)
    { }
}