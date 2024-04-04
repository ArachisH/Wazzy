namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConvertI32IntoF32_SIns : WASMInstruction
{
    public ConvertI32IntoF32_SIns()
        : base(OPCode.ConvertI32IntoF32_S)
    { }
}