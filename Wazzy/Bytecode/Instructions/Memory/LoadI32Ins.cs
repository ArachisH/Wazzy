using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI32Ins : MemoryInstruction
{
    public LoadI32Ins()
        : base(OPCode.LoadI32, true)
    { }
    public LoadI32Ins(ref WASMReader input)
        : base(OPCode.LoadI32, ref input, true)
    { }
    public LoadI32Ins(uint align, uint offset)
        : base(OPCode.LoadI32, align, offset)
    { }
}