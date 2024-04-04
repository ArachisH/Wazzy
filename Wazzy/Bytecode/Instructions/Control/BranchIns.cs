using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class BranchIns : WASMInstruction
{
    public uint LabelIndex { get; set; }

    public BranchIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }
    public BranchIns(uint labelIndex = 0)
        : base(OPCode.Branch)
    {
        LabelIndex = labelIndex;
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(LabelIndex);
    }

    protected override int GetBodySize() => WASMReader.GetULEB128Size(LabelIndex);
}