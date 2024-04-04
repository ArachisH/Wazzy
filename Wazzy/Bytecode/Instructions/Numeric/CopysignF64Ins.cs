namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class CopysignF64Ins : WASMInstruction
{
    public CopysignF64Ins()
        : base(OPCode.CopysignF64)
    { }
}