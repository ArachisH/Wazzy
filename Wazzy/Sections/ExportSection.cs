namespace Wazzy.Sections
{
    public class ExportSection : WASMSection
    {
        public string[] Names { get; }
        public byte[] Tags { get; }
        public int[] Indices { get; }

        public ExportSection(WASMModule module)
            : base(module, WASMSectionId.ExportSection)
        {
            int exports = module.Input.Read7BitEncodedInt();
            Names = new string[exports];
            Tags = new byte[exports];
            Indices = new int[exports];

            for (int i = 0; i < exports; i++)
            {
                Names[i] = module.Input.Read7BitEncodedString();
                Tags[i] = module.Input.ReadByte();
                Indices[i] = module.Input.Read7BitEncodedInt();
            }
        }
    }
}