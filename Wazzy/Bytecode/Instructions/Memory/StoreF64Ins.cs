using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreF64Ins : MemoryInstruction
{
    public StoreF64Ins()
        : base(OPCode.StoreF64, true)
    { }
    public StoreF64Ins(ref WASMReader input)
        : base(OPCode.StoreF64, ref input, true)
    { }
    public StoreF64Ins(uint align, uint offset)
        : base(OPCode.StoreF64, align, offset)
    { }
}