using System.Buffers;

namespace Wazzy.IO;

public abstract class WASMObject
{
    public void WriteTo(IBufferWriter<byte> output)
    {
        int size = GetSize();
        var writer = new WASMWriter(output.GetSpan(size));

        WriteTo(ref writer);
        output.Advance(size);
    }

    public abstract int GetSize();
    public abstract void WriteTo(ref WASMWriter output);
}