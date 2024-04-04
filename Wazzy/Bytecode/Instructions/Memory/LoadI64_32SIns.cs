using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI64_32SIns : MemoryInstruction
{
    public LoadI64_32SIns()
        : base(OPCode.LoadI64_32S, true)
    { }
    public LoadI64_32SIns(ref WASMReader input)
        : base(OPCode.LoadI64_32S, ref input, true)
    { }
    public LoadI64_32SIns(uint align, uint offset)
        : base(OPCode.LoadI64_32S, align, offset)
    { }
}