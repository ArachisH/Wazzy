using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI64_8Ins : MemoryInstruction
{
    public StoreI64_8Ins()
        : base(OPCode.StoreI64_8, true)
    { }
    public StoreI64_8Ins(ref WASMReader input)
        : base(OPCode.StoreI64_8, ref input, true)
    { }
    public StoreI64_8Ins(uint align, uint offset)
        : base(OPCode.StoreI64_8, align, offset)
    { }
}