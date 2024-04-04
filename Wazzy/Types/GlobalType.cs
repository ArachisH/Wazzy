using Wazzy.IO;

namespace Wazzy.Types;

public sealed class GlobalType : WASMType
{
    public Type ValueType { get; set; }
    public bool IsMutable { get; set; }

    public GlobalType(ref WASMReader input)
    {
        ValueType = input.ReadValueType();
        IsMutable = input.ReadBoolean();
    }

    public override void WriteTo(ref WASMWriter output)
    {
        output.Write(ValueType);
        output.Write(IsMutable);
    }
    public override int GetSize() => 2;

}