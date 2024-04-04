using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI32_8SIns : MemoryInstruction
{
    public LoadI32_8SIns()
        : base(OPCode.LoadI32_8S, true)
    { }
    public LoadI32_8SIns(ref WASMReader input)
        : base(OPCode.LoadI32_8S, ref input, true)
    { }
    public LoadI32_8SIns(uint align, uint offset)
        : base(OPCode.LoadI32_8S, align, offset)
    { }
}