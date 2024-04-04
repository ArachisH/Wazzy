namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DivideI32_SIns : WASMInstruction
{
    public DivideI32_SIns()
        : base(OPCode.DivideI32_S)
    { }
}