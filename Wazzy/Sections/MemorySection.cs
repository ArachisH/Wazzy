namespace Wazzy.Sections
{
    public class MemorySection : WASMSection
    {
        public MemorySection(WASMModule module)
            : base(module, WASMSectionId.MemorySection)
        { }
    }
}