using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections;

public sealed class TableSection : WASMSectionEnumerable<TableType>
{
    public TableSection(ref WASMReader input)
        : base(WASMSectionId.TableSection)
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new TableType(ref input));
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (TableType table in this)
        {
            size += table.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (TableType table in this)
        {
            table.WriteTo(ref output);
        }
    }
}