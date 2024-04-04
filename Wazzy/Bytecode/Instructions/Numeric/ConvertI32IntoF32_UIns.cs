namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConvertI32IntoF32_UIns : WASMInstruction
{
    public ConvertI32IntoF32_UIns()
        : base(OPCode.ConvertI32IntoF32_U)
    { }
}