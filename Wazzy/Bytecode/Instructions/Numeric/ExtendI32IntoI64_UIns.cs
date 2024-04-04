namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ExtendI32IntoI64_UIns : WASMInstruction
{
    public ExtendI32IntoI64_UIns()
        : base(OPCode.ExtendI32IntoI64_U)
    { }
}