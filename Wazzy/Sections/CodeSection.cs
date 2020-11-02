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
    }
}