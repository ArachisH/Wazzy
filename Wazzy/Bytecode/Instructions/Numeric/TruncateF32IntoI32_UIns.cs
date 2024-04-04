namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class TruncateF32IntoI32_UIns : WASMInstruction
{
    public TruncateF32IntoI32_UIns()
        : base(OPCode.TruncateF32IntoI32_U)
    { }
}