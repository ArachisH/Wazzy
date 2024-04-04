using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI32_16SIns : MemoryInstruction
{
    public LoadI32_16SIns()
        : base(OPCode.LoadI32_16S, true)
    { }
    public LoadI32_16SIns(ref WASMReader input)
        : base(OPCode.LoadI32_16S, ref input, true)
    { }
    public LoadI32_16SIns(uint align, uint offset)
        : base(OPCode.LoadI32_16S, align, offset)
    { }
}