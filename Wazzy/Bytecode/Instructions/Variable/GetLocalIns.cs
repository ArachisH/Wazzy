using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable;

public sealed class GetLocalIns : WASMInstruction
{
    public uint Index { get; set; }

    public GetLocalIns(uint index = 0)
        : base(OPCode.GetLocal)
    {
        Index = index;
    }
    public GetLocalIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }

    protected override int GetBodySize() => WASMReader.GetULEB128Size(Index);
    protected override void WriteBodyTo(ref WASMWriter output) => output.WriteULEB128(Index);
}