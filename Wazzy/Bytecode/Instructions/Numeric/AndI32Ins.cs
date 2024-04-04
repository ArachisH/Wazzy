namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class AndI32Ins : WASMInstruction
{
    public AndI32Ins()
        : base(OPCode.AndI32)
    { }

    public override void Execute(Stack<object> stack, WASMModule context, params object[] parameters)
    {
        var i1 = (int)stack.Pop();
        var i2 = (int)stack.Pop();
        stack.Push(i1 & i2);
    }
}