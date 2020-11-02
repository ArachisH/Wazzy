using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class GlobalSection : WASMSectionEnumerable<GlobalSubsection>
    {
        public GlobalSection(WASMModule module)
            : base(module, WASMSectionId.GlobalSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new GlobalSubsection(module));
            }
        }
    }
}