using System.Collections.Generic;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class AddI32Ins : WASMInstruction
    {
        public AddI32Ins()
            : base(OPCode.AddI32)
        { }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            var i1 = (int)stack.Pop();
            var i2 = (int)stack.Pop();
            stack.Push(i1 + i2);
        }
    }
}