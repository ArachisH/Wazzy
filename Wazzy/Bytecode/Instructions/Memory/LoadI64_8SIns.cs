using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI64_8SIns : MemoryInstruction
{
    public LoadI64_8SIns()
        : base(OPCode.LoadI64_8S, true)
    { }
    public LoadI64_8SIns(ref WASMReader input)
        : base(OPCode.LoadI64_8S, ref input, true)
    { }
    public LoadI64_8SIns(uint align, uint offset)
        : base(OPCode.LoadI64_8S, align, offset)
    { }
}