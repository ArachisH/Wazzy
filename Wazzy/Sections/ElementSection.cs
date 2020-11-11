using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class ElementSection : WASMSectionEnumerable<ElementSubsection>
    {
        public ElementSection(WASMModule module, ref WASMReader input)
            : base(WASMSectionId.ElementSection)
        {
            Subsections.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new ElementSubsection(module, ref input));
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Subsections.Count);
            foreach (ElementSubsection element in Subsections)
            {
                size += element.GetSize();
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Subsections.Count);
            foreach (ElementSubsection element in Subsections)
            {
                element.WriteTo(ref output);
            }
        }
    }
}