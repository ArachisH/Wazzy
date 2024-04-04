using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Bytecode.Instructions.Control;

public class BlockIns : WASMInstruction, IStructuredInstruction
{
    protected ElseIns _else;

    public Type BlockType { get; set; }
    public int? FunctionTypeIndex { get; set; }
    public List<WASMInstruction> Expression { get; }

    public BlockIns()
        : this(OPCode.Block)
    { }
    public BlockIns(ref WASMReader input)
        : this(ref input, OPCode.Block)
    { }

    protected BlockIns(OPCode op)
        : base(op)
    {
        Expression = new List<WASMInstruction>();
    }
    protected BlockIns(ref WASMReader input, OPCode op)
        : base(op)
    {
        byte blockId = input.ReadByte();
        if (blockId == 0x40)
        {
            BlockType = typeof(void);
        }
        else if (WASMType.IsSupportedValueTypeId(blockId))
        {
            BlockType = WASMType.GetValueType(blockId);
        }
        else // This is an index to a function type.
        {
            input.Position--;
            FunctionTypeIndex = input.ReadIntLEB128();
        }
        Expression = input.ReadExpression(op == OPCode.If);
        if (Expression[^1].OP == OPCode.Else)
        {
            _else = (ElseIns)Expression[^1];
            Expression.RemoveAt(Expression.Count - 1);
        }
    }

    ElseIns IStructuredInstruction.GetElseInstruction() => _else;

    protected override int GetBodySize()
    {
        int size = 0;
        if (FunctionTypeIndex != null)
        {
            size += WASMReader.GetLEB128Size((int)FunctionTypeIndex);
        }
        else size += 1; // Type

        foreach (var instruction in Expression)
        {
            size += instruction.GetSize();
        }
        size += _else?.GetSize() ?? 0;
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        if (FunctionTypeIndex != null)
        {
            output.WriteLEB128((int)FunctionTypeIndex);
        }
        else if (BlockType == typeof(void))
        {
            output.Write((byte)0x40);
        }
        else output.Write(BlockType);
        foreach (WASMInstruction instruction in Expression)
        {
            instruction.WriteTo(ref output);
        }
        _else?.WriteTo(ref output);
    }
}