using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections
{
    /// <summary>
    /// Represents a list of function signatures.
    /// </summary>
    public class TypeSection : WASMSectionEnumerable<FuncType>
    {
        public TypeSection(WASMModule module)
            : base(module, WASMSectionId.TypeSection)
        {
            Subsections.Capacity = module.Input.Read7BitEncodedInt();
            for (int i = 0; i < Subsections.Capacity; i++)
            {
                byte id = module.Input.ReadByte();
                if (id != 0x60) System.Diagnostics.Debugger.Break();
                Add(new FuncType(module));
            }
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedInt(Subsections.Count);
            foreach (FuncType functionType in Subsections)
            {
                output.Write((byte)0x60);
                functionType.WriteTo(output);
            }
        }
    }
}