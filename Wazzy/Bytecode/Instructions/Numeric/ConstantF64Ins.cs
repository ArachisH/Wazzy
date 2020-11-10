using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantF64Ins : WASMInstruction
    {
        public double Constant { get; set; }

        public ConstantF64Ins(WASMReader input)
            : this(input.ReadDouble())
        { }
        public ConstantF64Ins(double constant = 0)
            : base(OPCode.ConstantF64)
        {
            Constant = constant;
        }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            stack.Push(Constant);
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write(Constant);
        }
    }
}