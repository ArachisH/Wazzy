namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class TruncateF64IntoI64_UIns : WASMInstruction
{
    public TruncateF64IntoI64_UIns()
        : base(OPCode.TruncateF64IntoI64_U)
    { }
}