using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections;

public sealed class DataSection : WASMSectionEnumerable<DataSubsection>
{
    public DataSection(ref WASMReader input)
        : base(WASMSectionId.DataSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new DataSubsection(ref input));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (DataSubsection data in this)
        {
            size += data.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (DataSubsection data in this)
        {
            data.WriteTo(ref output);
        }
    }
}