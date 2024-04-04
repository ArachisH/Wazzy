using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI32_16UIns : MemoryInstruction
{
    public LoadI32_16UIns()
        : base(OPCode.LoadI32_16U, true)
    { }
    public LoadI32_16UIns(ref WASMReader input)
        : base(OPCode.LoadI32_16U, ref input, true)
    { }
    public LoadI32_16UIns(uint align, uint offset)
        : base(OPCode.LoadI32_16U, align, offset)
    { }
}