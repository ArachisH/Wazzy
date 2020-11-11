using Wazzy.IO;

namespace Wazzy.Sections
{
    public class FunctionSection : WASMSectionEnumerable<int>
    {
        public FunctionSection(ref WASMReader input)
            : base(WASMSectionId.FunctionSection)
        {
            Subsections.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Subsections.Add(input.ReadIntLEB128());
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Subsections.Count);
            foreach (int typeIndex in Subsections)
            {
                size += WASMReader.GetLEB128Size(typeIndex);
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Subsections.Count);
            foreach (int typeIndex in Subsections)
            {
                output.WriteLEB128(typeIndex);
            }
        }
    }
}