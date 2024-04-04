namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConvertI32IntoF64_SIns : WASMInstruction
{
    public ConvertI32IntoF64_SIns()
        : base(OPCode.ConvertI32IntoF64_S)
    { }
}