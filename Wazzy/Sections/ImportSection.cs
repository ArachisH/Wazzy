using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class ImportSection : WASMSectionEnumerable<ImportSubsection>
    {
        public ImportSection(WASMModule module)
            : base(module, WASMSectionId.ImportSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new ImportSubsection(module));
            }
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (ImportSubsection import in Subsections)
            {
                import.WriteTo(output);
            }
        }
    }
}