using Wazzy.IO;
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

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (DataSubsection data in Subsections)
            {
                data.WriteTo(output);
            }
        }
    }
}