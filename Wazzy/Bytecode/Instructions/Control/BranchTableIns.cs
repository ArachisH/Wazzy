using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class BranchTableIns : WASMInstruction
{
    public uint LabelIndex { get; set; }
    public List<uint> LabelIndices { get; }

    public BranchTableIns()
        : base(OPCode.BranchTable)
    {
        LabelIndices = new List<uint>();
    }
    public BranchTableIns(ref WASMReader input)
        : this()
    {
        LabelIndices.Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < LabelIndices.Capacity; i++)
        {
            LabelIndices.Add(input.ReadIntULEB128());
        }
        LabelIndex = input.ReadIntULEB128();
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)LabelIndices.Count);
        foreach (uint labelIndex in LabelIndices)
        {
            output.WriteULEB128(labelIndex);
        }
        output.WriteULEB128(LabelIndex);
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)LabelIndices.Count);
        foreach (uint labelIndex in LabelIndices)
        {
            size += WASMReader.GetULEB128Size(labelIndex);
        }
        size += WASMReader.GetULEB128Size(LabelIndex);
        return size;
    }
}