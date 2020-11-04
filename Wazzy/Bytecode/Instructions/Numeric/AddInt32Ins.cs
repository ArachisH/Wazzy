using System.Collections.Generic;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class AddInt32Ins : WASMInstruction
    {
        public AddInt32Ins()
            : base(OPCode.AddInt32)
        { }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            var i1 = (int)stack.Pop();
            var i2 = (int)stack.Pop();
            stack.Push(i1 + i2);
        }
    }
}