namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class MinF32Ins : WASMInstruction
{
    public MinF32Ins()
        : base(OPCode.MinF32)
    { }
}