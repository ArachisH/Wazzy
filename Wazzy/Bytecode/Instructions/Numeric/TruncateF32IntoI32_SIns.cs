namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class TruncateF32IntoI32_SIns : WASMInstruction
{
    public TruncateF32IntoI32_SIns()
        : base(OPCode.TruncateF32IntoI32_S)
    { }
}