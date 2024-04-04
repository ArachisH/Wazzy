using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConstantI32Ins : WASMInstruction
{
    public int Constant { get; set; }

    public ConstantI32Ins(ref WASMReader input)
        : this(input.ReadIntLEB128())
    { }
    public ConstantI32Ins(int constant = 0)
        : base(OPCode.ConstantI32)
    {
        Constant = constant;
    }

    public override void Execute(Stack<object> stack, WASMModule context, params object[] parameters)
    {
        stack.Push(Constant);
    }

    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteLEB128(Constant);
    }
    protected override int GetBodySize() => WASMReader.GetLEB128Size(Constant);
}