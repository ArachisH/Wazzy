namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class DivideI64_UIns : WASMInstruction
{
    public DivideI64_UIns()
        : base(OPCode.DivideI64_U)
    { }
}