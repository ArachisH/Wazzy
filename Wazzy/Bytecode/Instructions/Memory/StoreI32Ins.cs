using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI32Ins : MemoryInstruction
{
    public StoreI32Ins(ref WASMReader input)
        : base(OPCode.StoreI32, ref input, true)
    { }
    public StoreI32Ins(uint align, uint offset)
        : base(OPCode.StoreI32, align, offset)
    { }
}