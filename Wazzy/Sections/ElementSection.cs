using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections;

public sealed class ElementSection : WASMSectionEnumerable<ElementSubsection>
{
    public ElementSection(ref WASMReader input, IFunctionOffsetProvider functionOffsetProvider = null)
        : base(WASMSectionId.ElementSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new ElementSubsection(ref input, functionOffsetProvider));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (ElementSubsection element in this)
        {
            size += element.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (ElementSubsection element in this)
        {
            element.WriteTo(ref output);
        }
    }
}