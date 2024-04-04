namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MinF64Ins : WASMInstruction
{
    public MinF64Ins()
        : base(OPCode.MinF64)
    { }
}