using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections
{
    public class MemorySection : WASMSectionEnumerable<MemoryType>
    {
        public MemorySection(WASMModule module)
            : base(module, WASMSectionId.MemorySection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                Add(new MemoryType(module));
            }
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (MemoryType memory in Subsections)
            {
                memory.WriteTo(output);
            }
        }
    }
}