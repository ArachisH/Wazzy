using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class GlobalSection : WASMSectionEnumerable<GlobalSubsection>
    {
        public GlobalSection(ref WASMReader input)
            : base(WASMSectionId.GlobalSection)
        {
            Subsections.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new GlobalSubsection(ref input));
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Subsections.Count);
            foreach (GlobalSubsection global in Subsections)
            {
                size += global.GetSize();
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Subsections.Count);
            foreach (GlobalSubsection global in Subsections)
            {
                global.WriteTo(ref output);
            }
        }
    }
}