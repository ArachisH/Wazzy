using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class CallIns : WASMInstruction
{
    private readonly IFunctionOffsetProvider _functionOffsetProvider;

    public uint FunctionIndex { get; set; }

    public CallIns(uint functionIndex = 0)
        : base(OPCode.Call)
    {
        FunctionIndex = functionIndex;
    }
    public CallIns(ref WASMReader input, IFunctionOffsetProvider functionOffsetProvider = null)
        : this(input.ReadIntULEB128())
    {
        _functionOffsetProvider = functionOffsetProvider;
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(FunctionIndex + (uint)(_functionOffsetProvider?.FunctionOffset ?? 0));
    }
    protected override int GetBodySize() => WASMReader.GetULEB128Size(FunctionIndex + (uint)(_functionOffsetProvider?.FunctionOffset ?? 0));
}