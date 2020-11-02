namespace Wazzy.Sections
{
    public abstract class WASMSection
    {
        protected readonly WASMModule _module;

        public int Size { get; }
        public long EndPosition { get; }
        public long StartPosition { get; }

        public WASMSectionId Id { get; }

        public WASMSection(WASMModule module, WASMSectionId id)
        {
            _module = module;

            Id = id;
            Size = module.Input.Read7BitEncodedInt();
            StartPosition = module.Input.Position;
            EndPosition = module.Input.Position + Size;
        }
    }
}