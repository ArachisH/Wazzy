using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantF64Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantF64Ins(int constant = 0)
            : base(OPCode.ConstantF64)
        {
            Constant = constant;
        }
        public ConstantF64Ins(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            stack.Push(Constant);
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Constant);
        }
    }
}