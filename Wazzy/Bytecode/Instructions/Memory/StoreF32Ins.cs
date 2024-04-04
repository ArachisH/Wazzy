using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreF32Ins : MemoryInstruction
{
    public StoreF32Ins()
        : base(OPCode.StoreF32, true)
    { }
    public StoreF32Ins(ref WASMReader input)
        : base(OPCode.StoreF32, ref input, true)
    { }
    public StoreF32Ins(uint align, uint offset)
        : base(OPCode.StoreF32, align, offset)
    { }
}