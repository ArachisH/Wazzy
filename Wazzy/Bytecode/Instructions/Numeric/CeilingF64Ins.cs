namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class CeilingF64Ins : WASMInstruction
{
    public CeilingF64Ins()
        : base(OPCode.CeilingF64)
    { }
}