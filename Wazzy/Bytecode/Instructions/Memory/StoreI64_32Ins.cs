using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI64_32Ins : MemoryInstruction
{
    public StoreI64_32Ins()
        : base(OPCode.StoreI64_32, true)
    { }
    public StoreI64_32Ins(ref WASMReader input)
        : base(OPCode.StoreI64_32, ref input, true)
    { }
    public StoreI64_32Ins(uint align, uint offset)
        : base(OPCode.StoreI64_32, align, offset)
    { }
}