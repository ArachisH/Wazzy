using System;

using Wazzy.IO;

namespace Wazzy.Sections
{
    public class CustomSection : WASMSection
    {
        public string Name { get; }
        public byte[] Data { get; set; }

        public CustomSection(WASMModule module)
            : base(module, WASMSectionId.CustomSection)
        {
            int possibleNameLength = module.Input.Read7BitEncodedInt();
            Name = module.Input.ReadString(possibleNameLength);

            int leftOverSectionData = Size - possibleNameLength - WASMReader.Get7BitEncodedIntSize(possibleNameLength);
            Data = module.Input.ReadBytes(leftOverSectionData);

            if (leftOverSectionData != Data.Length)
            {
                throw new Exception("Failed to properly read custom section data");
            }
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedString(Name);
            output.Write(Data);
        }
    }
}