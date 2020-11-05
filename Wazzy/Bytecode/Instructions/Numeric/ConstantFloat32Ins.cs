﻿using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric
{
    public class ConstantFloat32Ins : WASMInstruction
    {
        public int Constant { get; set; }

        public ConstantFloat32Ins(int constant = 0)
            : base(OPCode.ConstantFloat32)
        {
            Constant = constant;
        }
        public ConstantFloat32Ins(WASMReader input)
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