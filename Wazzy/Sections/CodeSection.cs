using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class CodeSection : WASMSectionEnumerable<CodeSubsection>
    {
        public CodeSection(WASMModule module)
            : base(module, WASMSectionId.CodeSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new CodeSubsection(module));
            }
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (CodeSubsection code in Subsections)
            {
                code.WriteTo(output);
            }
        }
    }
}