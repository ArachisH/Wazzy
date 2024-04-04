using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadF32Ins : MemoryInstruction
{
    public LoadF32Ins()
        : base(OPCode.LoadF32, true)
    { }
    public LoadF32Ins(ref WASMReader input)
        : base(OPCode.LoadF32, ref input, true)
    { }
    public LoadF32Ins(uint align, uint offset)
        : base(OPCode.LoadF32, align, offset)
    { }
}