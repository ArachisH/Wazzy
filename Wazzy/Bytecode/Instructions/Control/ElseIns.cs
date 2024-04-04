using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class ElseIns : WASMInstruction, IStructuredInstruction
{
    public List<WASMInstruction> Expression { get; set; }

    public ElseIns()
        : base(OPCode.Else)
    {
        Expression = new List<WASMInstruction>();
    }
    public ElseIns(ref WASMReader input)
        : base(OPCode.Else)
    {
        Expression = input.ReadExpression();
    }

    protected override int GetBodySize()
    {
        int size = 0;
        foreach (WASMInstruction instruction in Expression)
        {
            size += instruction.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        foreach (WASMInstruction instruction in Expression)
        {
            instruction.WriteTo(ref output);
        }
    }
}