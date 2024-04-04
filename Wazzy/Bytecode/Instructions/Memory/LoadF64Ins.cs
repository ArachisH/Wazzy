using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadF64Ins : MemoryInstruction
{
    public LoadF64Ins()
        : base(OPCode.LoadF64, true)
    { }
    public LoadF64Ins(ref WASMReader input)
        : base(OPCode.LoadF64, ref input, true)
    { }
    public LoadF64Ins(uint align, uint offset)
        : base(OPCode.LoadF64, align, offset)
    { }
}