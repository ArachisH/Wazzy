using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable;

public sealed class SetGlobalIns : WASMInstruction
{
    public uint Index { get; set; }

    public SetGlobalIns(uint index = 0)
        : base(OPCode.SetGlobal)
    {
        Index = index;
    }
    public SetGlobalIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(Index);
    }
    protected override int GetBodySize() => WASMReader.GetULEB128Size(Index);
}