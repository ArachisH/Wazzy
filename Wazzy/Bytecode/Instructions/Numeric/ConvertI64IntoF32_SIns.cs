namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConvertI64IntoF32_SIns : WASMInstruction
{
    public ConvertI64IntoF32_SIns()
        : base(OPCode.ConvertI64IntoF32_S)
    { }
}