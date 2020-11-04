using System.Collections.Generic;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class EqualsZeroInt32Ins : WASMInstruction
    {
        public EqualsZeroInt32Ins()
            : base(OPCode.EqualsZeroInt32)
        { }

        public override void Execute(Stack<object> stack, WASMModule context) => stack.Push((int)stack.Pop() == 0);
    }
}