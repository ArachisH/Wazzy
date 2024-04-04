using Wazzy.IO;

namespace Wazzy.Types;

public sealed class Local : WASMType
{
    public uint Rank { get; set; }
    public Type Type { get; set; }

    public Local(ref WASMReader input)
    {
        Rank = input.ReadIntULEB128();
        Type = input.ReadValueType();
    }

    public override int GetSize() => WASMReader.GetULEB128Size(Rank) + 1;
    public override void WriteTo(ref WASMWriter output)
    {
        output.WriteULEB128(Rank);
        output.Write(Type);
    }
}