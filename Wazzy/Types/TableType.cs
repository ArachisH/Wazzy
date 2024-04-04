using Wazzy.IO;

namespace Wazzy.Types;

public sealed class TableType : WASMType
{
    public byte ElementType { get; set; }
    public Limits Limits { get; set; }

    public TableType(ref WASMReader input)
    {
        ElementType = input.ReadByte(); // WASM v1 only supports funcref(0x70), but will perhaps support more in the future.
        Limits = new Limits(ref input);
    }

    public override void WriteTo(ref WASMWriter output)
    {
        output.Write(ElementType);
        Limits.WriteTo(ref output);
    }

    public override int GetSize()
    {
        int size = 0;
        size += sizeof(byte);
        size += Limits.GetSize();
        return size;
    }
}