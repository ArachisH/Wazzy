using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections;

public sealed class GlobalSection : WASMSectionEnumerable<GlobalSubsection>
{
    public GlobalSection(ref WASMReader input)
        : base(WASMSectionId.GlobalSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new GlobalSubsection(ref input));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (GlobalSubsection global in this)
        {
            size += global.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (GlobalSubsection global in this)
        {
            global.WriteTo(ref output);
        }
    }
}