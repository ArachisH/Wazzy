namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class RemainderI32_UIns : WASMInstruction
{
    public RemainderI32_UIns()
        : base(OPCode.RemainderI32_U)
    { }
}