namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConvertI64IntoF64_SIns : WASMInstruction
{
    public ConvertI64IntoF64_SIns()
        : base(OPCode.ConvertI64IntoF64_S)
    { }
}