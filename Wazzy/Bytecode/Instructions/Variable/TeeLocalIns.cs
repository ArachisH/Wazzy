using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable;

public sealed class TeeLocalIns : WASMInstruction
{
    public uint Index { get; set; }

    public TeeLocalIns(uint index = 0)
        : base(OPCode.TeeLocal)
    {
        Index = index;
    }
    public TeeLocalIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(Index);
    }
    protected override int GetBodySize() => WASMReader.GetULEB128Size(Index);
}