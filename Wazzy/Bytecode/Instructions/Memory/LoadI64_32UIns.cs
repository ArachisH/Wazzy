using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class LoadI64_32UIns : MemoryInstruction
{
    public LoadI64_32UIns()
        : base(OPCode.LoadI64_32U, true)
    { }
    public LoadI64_32UIns(ref WASMReader input)
        : base(OPCode.LoadI64_32U, ref input, true)
    { }
    public LoadI64_32UIns(uint align, uint offset)
        : base(OPCode.LoadI64_32U, align, offset)
    { }
}