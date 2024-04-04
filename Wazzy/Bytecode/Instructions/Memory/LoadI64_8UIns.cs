using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI64_8UIns : MemoryInstruction
{
    public LoadI64_8UIns()
        : base(OPCode.LoadI64_8U, true)
    { }
    public LoadI64_8UIns(ref WASMReader input)
        : base(OPCode.LoadI64_8U, ref input, true)
    { }
    public LoadI64_8UIns(uint align, uint offset)
        : base(OPCode.LoadI64_8U, align, offset)
    { }
}