using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections;

public sealed class MemorySection : WASMSectionEnumerable<MemoryType>
{
    public MemorySection(ref WASMReader input)
        : base(WASMSectionId.MemorySection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new MemoryType(ref input));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (MemoryType memory in this)
        {
            size += memory.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (MemoryType memory in this)
        {
            memory.WriteTo(ref output);
        }
    }
}