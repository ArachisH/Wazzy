using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory;

public abstract class MemoryInstruction : WASMInstruction
{
    private readonly bool _hasMemArgs;

    public uint Align { get; set; }
    public uint Offset { get; set; }

    public MemoryInstruction(OPCode op, bool hasMemArgs)
        : base(op)
    {
        _hasMemArgs = hasMemArgs;
    }
    public MemoryInstruction(OPCode op, uint align, uint offset)
        : this(op, true)
    {
        Align = align;
        Offset = offset;
    }
    protected MemoryInstruction(OPCode op, ref WASMReader input, bool hasMemArgs)
        : this(op, hasMemArgs)
    {
        if (_hasMemArgs = hasMemArgs)
        {
            Align = input.ReadIntULEB128();
            Offset = input.ReadIntULEB128();
        }
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        if (_hasMemArgs)
        {
            output.WriteULEB128(Align);
            output.WriteULEB128(Offset);
        }
    }
    protected override int GetBodySize() => _hasMemArgs ? WASMReader.GetULEB128Size(Align) + WASMReader.GetULEB128Size(Offset) : sizeof(byte);
}