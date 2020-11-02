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
    }
}