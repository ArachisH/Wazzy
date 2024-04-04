using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI64_16Ins : MemoryInstruction
{
    public StoreI64_16Ins()
        : base(OPCode.StoreI64_16, true)
    { }
    public StoreI64_16Ins(ref WASMReader input)
        : base(OPCode.StoreI64_16, ref input, true)
    { }
    public StoreI64_16Ins(uint align, uint offset)
        : base(OPCode.StoreI64_16, align, offset)
    { }
}