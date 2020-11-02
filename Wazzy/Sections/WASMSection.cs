namespace Wazzy.Sections
{
    public abstract class WASMSection
    {
        protected readonly WASMModule _module;

        public int Size { get; }
        public int Start { get; }

        public WASMSectionId Id { get; }

        public WASMSection(WASMModule module, WASMSectionId id)
        {
            _module = module;

            Id = id;
            Size = module.Input.Read7BitEncodedInt();
            Start = module.Input.Position;
        }
    }
}