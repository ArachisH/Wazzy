using Wazzy.IO;

namespace Wazzy.Sections;

public sealed class FunctionSection : WASMSectionEnumerable<uint>
{
    public FunctionSection(ref WASMReader input)
        : base(WASMSectionId.FunctionSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(input.ReadIntULEB128());
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (uint functionTypeIndex in this)
        {
            size += WASMReader.GetULEB128Size(functionTypeIndex);
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (uint functionTypeIndex in this)
        {
            output.WriteULEB128(functionTypeIndex);
        }
    }
}