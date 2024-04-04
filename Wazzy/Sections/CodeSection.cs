using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections;

public sealed class CodeSection : WASMSectionEnumerable<CodeSubsection>
{
    public CodeSection(ref WASMReader input, IFunctionOffsetProvider functionOffsetProvider)
        : base(WASMSectionId.CodeSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new CodeSubsection(ref input, functionOffsetProvider));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (CodeSubsection code in this)
        {
            size += code.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (CodeSubsection code in this)
        {
            code.WriteTo(ref output);
        }
    }
}