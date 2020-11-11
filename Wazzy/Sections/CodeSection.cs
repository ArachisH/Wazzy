using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections
{
    public class CodeSection : WASMSectionEnumerable<CodeSubsection>
    {
        public CodeSection(ref WASMReader input)
            : base(WASMSectionId.CodeSection)
        {
            Subsections.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new CodeSubsection(ref input));
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Subsections.Count);
            foreach (CodeSubsection code in Subsections)
            {
                size += code.GetSize();
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Subsections.Count);
            foreach (CodeSubsection code in Subsections)
            {
                code.WriteTo(ref output);
            }
        }
    }
}