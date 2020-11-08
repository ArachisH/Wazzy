using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantI32Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantI32Ins(int constant = 0)
            : base(OPCode.ConstantI32)
        {
            Constant = constant;
        }
        public ConstantI32Ins(WASMReader input)
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