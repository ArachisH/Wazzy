using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConstantI64Ins : WASMInstruction
{
    public long Constant { get; set; }

    public ConstantI64Ins(ref WASMReader input)
        : this(input.ReadLongLEB128())
    { }
    public ConstantI64Ins(long constant = 0)
        : base(OPCode.ConstantI64)
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