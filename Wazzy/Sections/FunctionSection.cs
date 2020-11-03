using Wazzy.IO;

namespace Wazzy.Sections
{
    public class FunctionSection : WASMSectionEnumerable<int>
    {
        public FunctionSection(WASMModule module)
            : base(module, WASMSectionId.FunctionSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Subsections.Add(module.Input.Read7BitEncodedInt());
            }
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (int typeIndex in Subsections)
            {
                output.Write7BitEncodedInt(typeIndex);
            }
        }
    }
}