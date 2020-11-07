using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantFloat64Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantFloat64Ins(int constant = 0)
            : base(OPCode.ConstantFloat64)
        {
            Constant = constant;
        }
        public ConstantFloat64Ins(WASMReader input)
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