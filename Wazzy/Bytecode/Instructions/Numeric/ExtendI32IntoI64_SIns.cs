namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ExtendI32IntoI64_SIns : WASMInstruction
{
    public ExtendI32IntoI64_SIns()
        : base(OPCode.ExtendI32IntoI64_S)
    { }
}