namespace Wazzy.Sections
{
    public class StartSection : WASMSection
    {
        public StartSection(WASMModule module)
            : base(module, WASMSectionId.StartSection)
        { }
    }
}