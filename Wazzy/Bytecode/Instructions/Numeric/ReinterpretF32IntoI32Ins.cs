namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ReinterpretF32IntoI32Ins : WASMInstruction
{
    public ReinterpretF32IntoI32Ins()
        : base(OPCode.ReinterpretF32IntoI32)
    { }
}