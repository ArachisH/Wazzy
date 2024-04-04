namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConvertI32IntoF64_UIns : WASMInstruction
{
    public ConvertI32IntoF64_UIns()
        : base(OPCode.ConvertI32IntoF64_U)
    { }
}