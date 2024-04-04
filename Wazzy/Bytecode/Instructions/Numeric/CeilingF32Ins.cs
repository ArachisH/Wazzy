namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class CeilingF32Ins : WASMInstruction
{
    public CeilingF32Ins()
        : base(OPCode.CeilingF32)
    { }
}