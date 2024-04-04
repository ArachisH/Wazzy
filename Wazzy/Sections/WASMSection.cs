using Wazzy.IO;

namespace Wazzy.Sections;

public abstract class WASMSection : WASMObject
{
    public WASMSectionId Id { get; }

    public WASMSection(WASMSectionId id) => Id = id;

    public override int GetSize()
    {
        int sectionSize = GetBodySize();
        int size = 0;
        size += sizeof(byte);
        size += WASMReader.GetULEB128Size((uint)sectionSize);
        size += sectionSize;
        return size;
    }
    public override void WriteTo(ref WASMWriter output)
    {
        output.Write((byte)Id);
        output.WriteULEB128((uint)GetBodySize());
        WriteBodyTo(ref output);
    }

    protected abstract int GetBodySize();
    protected abstract void WriteBodyTo(ref WASMWriter output);
}