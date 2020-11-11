using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections
{
    public class TableSection : WASMSectionEnumerable<TableType>
    {
        public TableSection(ref WASMReader input)
            : base(WASMSectionId.TableSection)
        {
            Subsections.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new TableType(ref input));
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Subsections.Count);
            foreach (TableType table in Subsections)
            {
                size += table.GetSize();
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Subsections.Count);
            foreach (TableType table in Subsections)
            {
                table.WriteTo(ref output);
            }
        }
    }
}