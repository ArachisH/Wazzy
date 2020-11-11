using System;
using System.Text;

using Wazzy.IO;

namespace Wazzy.Sections
{
    public class CustomSection : WASMSection
    {
        public string Name { get; }
        public byte[] Data { get; set; }

        public CustomSection(int length, ref WASMReader input)
            : base(WASMSectionId.CustomSection)
        {
            int possibleNameLength = input.ReadIntLEB128();
            Name = input.ReadString(possibleNameLength);

            int leftOverSectionData = length - possibleNameLength - WASMReader.GetLEB128Size(possibleNameLength);
            Data = input.ReadBytes(leftOverSectionData).ToArray();

            if (leftOverSectionData != Data.Length)
            {
                throw new Exception("Failed to properly read custom section data");
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Name.Length);
            size += Encoding.UTF8.GetByteCount(Name);
            size += Data.Length;
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteString(Name);
            output.Write(Data);
        }
    }
}