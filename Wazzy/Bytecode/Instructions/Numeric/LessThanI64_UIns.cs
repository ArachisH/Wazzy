namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class LessThanI64_UIns : WASMInstruction
{
    public LessThanI64_UIns()
        : base(OPCode.LessThanI64_U)
    { }
}