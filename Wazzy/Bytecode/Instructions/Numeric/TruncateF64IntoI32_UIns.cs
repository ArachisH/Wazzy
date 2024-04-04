namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class TruncateF64IntoI32_UIns : WASMInstruction
{
    public TruncateF64IntoI32_UIns()
        : base(OPCode.TruncateF64IntoI32_U)
    { }
}