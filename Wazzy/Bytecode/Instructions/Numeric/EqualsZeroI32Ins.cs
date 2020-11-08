using System.Collections.Generic;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class EqualsZeroI32Ins : WASMInstruction
    {
        public EqualsZeroI32Ins()
            : base(OPCode.EqualsZeroI32)
        { }

        public override void Execute(Stack<object> stack, WASMModule context) => stack.Push((int)stack.Pop() == 0);
    }
}