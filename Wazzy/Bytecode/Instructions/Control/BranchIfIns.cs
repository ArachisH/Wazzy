using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class BranchIfIns : WASMInstruction
{
    public uint LabelIndex { get; set; }

    public BranchIfIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }
    public BranchIfIns(uint labelIndex = 0)
        : base(OPCode.BranchIf)
    {
        LabelIndex = labelIndex;
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(LabelIndex);
    }

    protected override int GetBodySize() => WASMReader.GetULEB128Size(LabelIndex);
}