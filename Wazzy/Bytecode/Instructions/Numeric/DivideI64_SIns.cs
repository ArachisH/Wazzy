namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DivideI64_SIns : WASMInstruction
{
    public DivideI64_SIns()
        : base(OPCode.DivideI64_S)
    { }
}