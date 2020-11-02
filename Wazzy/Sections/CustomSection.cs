using System.Text;

namespace Wazzy.Sections
{
    public class CustomSection : WASMSection
    {
        public string Name { get; }
        public byte[] Data { get; set; }

        public CustomSection(WASMModule module)
            : base(module, WASMSectionId.CustomSection)
        {
            int nameLength = module.Input.Read7BitEncodedInt();
            Data = module.Input.ReadBytes(nameLength);
            if (nameLength == Data.Length) // Otherwise, a blob of data was provided as the 'name' of this custom section.
            {
                Name = Encoding.UTF8.GetString(Data);
            }
        }
    }
}