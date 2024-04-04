using System.Diagnostics;

using Wazzy.IO;

namespace Wazzy.Types;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class Limits : WASMType
{
    public uint Minimum { get; set; }
    public uint Maximum { get; set; } = uint.MaxValue;

    public bool HasMaximum => Maximum != uint.MaxValue;

    internal string DebuggerDisplay => $"Min: {Minimum:n0}; Max: {Maximum:n0}";

    public Limits(uint minimum, uint maximum = uint.MaxValue)
    {
        Minimum = minimum;
        Maximum = maximum;
    }
    public Limits(ref WASMReader input)
    {
        bool hasMaximum = input.ReadBoolean();
        Minimum = input.ReadIntULEB128();
        if (hasMaximum)
        {
            Maximum = input.ReadIntULEB128();
        }
    }

    public override void WriteTo(ref WASMWriter output)
    {
        output.Write(HasMaximum);
        output.WriteULEB128(Minimum);
        if (HasMaximum)
        {
            output.WriteULEB128(Maximum);
        }
    }

    public override int GetSize()
    {
        int size = 0;
        size += sizeof(byte);
        size += WASMReader.GetULEB128Size(Minimum);
        if (HasMaximum)
            size += WASMReader.GetULEB128Size(Maximum);
        return size;
    }
}