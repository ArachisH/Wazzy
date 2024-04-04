using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI32_16Ins : MemoryInstruction
{
    public StoreI32_16Ins()
        : base(OPCode.StoreI32_16, true)
    { }
    public StoreI32_16Ins(ref WASMReader input)
        : base(OPCode.StoreI32_16, ref input, true)
    { }
    public StoreI32_16Ins(uint align, uint offset)
        : base(OPCode.StoreI32_16, align, offset)
    { }
}