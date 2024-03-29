﻿using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Numeric;

public sealed class ConstantF64Ins : WASMInstruction
{
    public double Constant { get; set; }

    public ConstantF64Ins(ref WASMReader input)
        : this(input.ReadDouble())
    { }
    public ConstantF64Ins(double constant = 0)
        : base(OPCode.ConstantF64)
    {
        Constant = constant;
    }

    public override void Execute(Stack<object> stack, WASMModule context, params object[] parameters)
    {
        stack.Push(Constant);
    }

    protected override int GetBodySize() => sizeof(double);
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.Write(Constant);
    }
}