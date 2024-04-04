using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI64Ins : MemoryInstruction
{
    public LoadI64Ins()
        : base(OPCode.LoadI64, true)
    { }
    public LoadI64Ins(ref WASMReader input)
        : base(OPCode.LoadI64, ref input, true)
    { }
    public LoadI64Ins(uint align, uint offset)
        : base(OPCode.LoadI64, align, offset)
    { }
}