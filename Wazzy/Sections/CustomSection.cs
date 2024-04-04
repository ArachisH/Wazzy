using System.Text;

using Wazzy.IO;

namespace Wazzy.Sections;

public sealed class CustomSection : WASMSection
{
    public string Name { get; set; }
    public byte[] Package { get; set; }

    public CustomSection(int length, ref WASMReader input)
        : base(WASMSectionId.CustomSection)
    {
        int nameSize = (int)input.ReadIntULEB128();
        Name = Encoding.UTF8.GetString(input.ReadBytes(nameSize));

        int leftOverSectionData = length - nameSize - WASMReader.GetLEB128Size(nameSize);
        Package = input.ReadBytes(leftOverSectionData).ToArray();

        if (leftOverSectionData != Package.Length)
        {
            throw new Exception("Failed to properly read custom section data");
        }
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size(Name);
        size += Package.Length;
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteString(Name);
        output.Write(Package);
    }
}