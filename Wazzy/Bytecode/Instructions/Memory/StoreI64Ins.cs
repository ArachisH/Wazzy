using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class StoreI64Ins : MemoryInstruction
{
    public StoreI64Ins()
        : base(OPCode.StoreI64, true)
    { }
    public StoreI64Ins(ref WASMReader input)
        : base(OPCode.StoreI64, ref input, true)
    { }
    public StoreI64Ins(uint align, uint offset)
        : base(OPCode.StoreI64, align, offset)
    { }
}