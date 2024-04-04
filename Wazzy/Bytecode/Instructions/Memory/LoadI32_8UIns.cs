
using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI32_8UIns : MemoryInstruction
{
    public LoadI32_8UIns()
        : base(OPCode.LoadI32_8U, true)
    { }
    public LoadI32_8UIns(ref WASMReader input)
        : base(OPCode.LoadI32_8U, ref input, true)
    { }
    public LoadI32_8UIns(uint align, uint offset)
        : base(OPCode.LoadI32_8U, align, offset)
    { }
}