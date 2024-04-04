using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI32_8Ins : MemoryInstruction
{
    public StoreI32_8Ins()
        : base(OPCode.StoreI32_8, true)
    { }
    public StoreI32_8Ins(ref WASMReader input)
        : base(OPCode.StoreI32_8, ref input, true)
    { }
    public StoreI32_8Ins(uint align, uint offset)
        : base(OPCode.StoreI32_8, align, offset)
    { }
}