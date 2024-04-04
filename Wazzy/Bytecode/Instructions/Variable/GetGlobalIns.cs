using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable;

public sealed class GetGlobalIns : WASMInstruction
{
    public uint Index { get; set; }

    public GetGlobalIns(uint index = 0)
        : base(OPCode.GetGlobal)
    {
        Index = index;
    }
    public GetGlobalIns(ref WASMReader input)
        : this(input.ReadIntULEB128())
    { }

    public override void Execute(Stack<object> stack, WASMModule context, params object[] parameters)
    {
        WASMMachine.Execute(context.GlobalSec[(int)Index].Expression, context, stack);
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128(Index);
    }
    protected override int GetBodySize() => WASMReader.GetULEB128Size(Index);
}