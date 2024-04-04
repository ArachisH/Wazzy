using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class CallIndirectIns : WASMInstruction
{
    public uint TypeIndex { get; set; }

    public CallIndirectIns(uint typeIndex)
        : base(OPCode.CallIndirect)
    {
        TypeIndex = typeIndex;
    }
    public CallIndirectIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    {
        /* In future versions of WebAssembly, the zero byte occurring in the encoding of the call_indirect instruction may be used to index additional tables. */
        input.Position++;
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(TypeIndex);
        output.Write((byte)0);
    }

    protected override int GetBodySize() => WASMReader.GetULEB128Size(TypeIndex) + sizeof(byte);
}