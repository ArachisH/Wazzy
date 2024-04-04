using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public sealed class MemoryGrowIns : MemoryInstruction
{
    public byte Index { get; set; }

    public MemoryGrowIns(byte index = 0)
        : base(OPCode.MemoryGrow, false)
    {
        Index = index;
    }
    public MemoryGrowIns(ref WASMReader input)
        : this(input.ReadByte())
    { }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.Write(Index);
    }
}