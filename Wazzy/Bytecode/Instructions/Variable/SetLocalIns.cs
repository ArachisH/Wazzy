using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable;

public sealed class SetLocalIns : WASMInstruction
{
    public uint Index { get; set; }

    public SetLocalIns(uint index = 0)
        : base(OPCode.SetLocal)
    {
        Index = index;
    }
    public SetLocalIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(Index);
    }
    protected override int GetBodySize() => WASMReader.GetULEB128Size(Index);
}