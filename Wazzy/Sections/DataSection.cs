using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class DataSection : WASMSectionEnumerable<DataSubsection>
    {
        public DataSection(WASMModule module, ref WASMReader input)
            : base(WASMSectionId.DataSection)
        {
            Subsections.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new DataSubsection(module, ref input));
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Subsections.Count);
            foreach (DataSubsection data in Subsections)
            {
                size += data.GetSize();
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Subsections.Count);
            foreach (DataSubsection data in Subsections)
            {
                data.WriteTo(ref output);
            }
        }
    }
}