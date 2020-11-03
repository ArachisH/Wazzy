using System.Collections.Generic;

namespace Wazzy.Bytecode
{
    public class WASMMachine
    {
        public Stack<object> Stack { get; }

        public WASMMachine()
        {
            Stack = new Stack<object>();
        }

        public static Stack<object> Execute(IList<WASMInstruction> expression, WASMModule context)
        {
            var stack = new Stack<object>();
            Execute(expression, context, stack);
            return stack;
        }
        public static void Execute(IList<WASMInstruction> expression, WASMModule context, Stack<object> stack)
        {
            foreach (WASMInstruction instruction in expression)
            {
                if (instruction.OP == OPCode.End) break;
                instruction.Execute(stack, context);
            }
        }
    }
}