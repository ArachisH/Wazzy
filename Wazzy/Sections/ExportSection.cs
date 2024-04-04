using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections;

public sealed class ExportSection : WASMSectionEnumerable<ExportSubsection>
{
    public ExportSection(ref WASMReader input, IFunctionOffsetProvider functionOffsetProvider = null)
        : base(WASMSectionId.ExportSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new ExportSubsection(ref input, functionOffsetProvider));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (ExportSubsection export in this)
        {
            size += export.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (ExportSubsection export in this)
        {
            export.WriteTo(ref output);
        }
    }
}