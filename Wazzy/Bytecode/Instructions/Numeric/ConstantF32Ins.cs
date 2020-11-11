using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantF32Ins : WASMInstruction
    {
        public float Constant { get; set; }

        public ConstantF32Ins(ref WASMReader input)
            : this(input.ReadSingle())
        { }
        public ConstantF32Ins(float constant = 0)
            : base(OPCode.ConstantF32)
        {
            Constant = constant;
        }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            stack.Push(Constant);
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.Write(Constant);
        }

        protected override int GetBodySize() => sizeof(float);
    }
}