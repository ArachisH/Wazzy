using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class ElementSection : WASMSectionEnumerable<ElementSubsection>
    {
        public ElementSection(WASMModule module)
            : base(module, WASMSectionId.ElementSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new ElementSubsection(module));
            }
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (ElementSubsection element in Subsections)
            {
                element.WriteTo(output);
            }
        }
    }
}