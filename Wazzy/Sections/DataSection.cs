using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class DataSection : WASMSectionEnumerable<DataSubsection>
    {
        public DataSection(WASMModule module)
            : base(module, WASMSectionId.DataSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new DataSubsection(module));
            }
        }
    }
}