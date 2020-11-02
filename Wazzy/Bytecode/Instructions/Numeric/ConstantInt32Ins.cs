using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantInt32Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantInt32Ins()
            : base(OPCode.ConstantInt32)
        { }
        public ConstantInt32Ins(int constant)
            : this()
        {
            Constant = constant;
        }
        public ConstantInt32Ins(WASMReader input)
            : this()
        {
            Constant = input.Read7BitEncodedInt();
        }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            stack.Push(Constant);
        }
    }
}