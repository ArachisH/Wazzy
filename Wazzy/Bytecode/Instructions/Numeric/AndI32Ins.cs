using System.Collections.Generic;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class AndI32Ins : WASMInstruction
    {
        public AndI32Ins()
            : base(OPCode.AndI32)
        { }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            var i1 = (int)stack.Pop();
            var i2 = (int)stack.Pop();
            stack.Push(i1 & i2);
        }
    }
}