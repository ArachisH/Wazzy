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
    }
}