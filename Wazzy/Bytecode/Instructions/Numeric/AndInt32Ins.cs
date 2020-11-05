using System.Collections.Generic;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class AndInt32Ins : WASMInstruction
    {
        public AndInt32Ins()
            : base(OPCode.AndInt32)
        { }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            var i1 = (int)stack.Pop();
            var i2 = (int)stack.Pop();
            stack.Push(i1 & i2);
        }
    }
}