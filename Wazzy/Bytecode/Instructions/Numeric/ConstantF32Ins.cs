using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConstantF32Ins : WASMInstruction
{
    public float Constant { get; set; }

    public ConstantF32Ins(float constant = 0)
        : base(OPCode.ConstantF32)
    {
        Constant = constant;
    }
    public ConstantF32Ins(ref WASMReader input)
        : this(input.ReadSingle())
    { }

    public override void Execute(Stack<object> stack, WASMModule context, params object[] parameters)
    {
        stack.Push(Constant);
    }

    protected override int GetBodySize() => sizeof(float);
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.Write(Constant);
    }
}