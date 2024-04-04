namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class GreaterThanI64_UIns : WASMInstruction
{
    public GreaterThanI64_UIns()
       : base(OPCode.GreaterThanI64_U)
    { }
}