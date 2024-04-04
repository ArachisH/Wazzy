namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ReinterpretI32IntoF32Ins : WASMInstruction
{
    public ReinterpretI32IntoF32Ins()
        : base(OPCode.ReinterpretI32IntoF32)
    { }
}