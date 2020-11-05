using System;
using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode.Instructions.Memory;
using Wazzy.Bytecode.Instructions.Numeric;
using Wazzy.Bytecode.Instructions.Control;
using Wazzy.Bytecode.Instructions.Variable;
using Wazzy.Bytecode.Instructions.Parametric;

namespace Wazzy.Bytecode
{
    public abstract class WASMInstruction : WASMObject
    {
        public OPCode OP { get; }

        public WASMInstruction(OPCode op) => OP = op;

        public void Execute(Stack<object> stack)
        {
            Execute(stack, null);
        }
        public virtual void Execute(Stack<object> stack, WASMModule context)
        { }

        public override void WriteTo(WASMWriter output)
        {
            output.Write((byte)OP);
            WriteBodyTo(output);
        }
        protected virtual void WriteBodyTo(WASMWriter output)
        { }

        public static WASMInstruction Create(OPCode op, WASMReader input = null) => op switch
        {
            // Control
            OPCode.Unreachable => new UnreachableIns(),
            OPCode.Nop => new NopIns(),
            OPCode.Block => new BlockIns(input),
            OPCode.Loop => new LoopIns(input),
            OPCode.If => new IfIns(input),
            OPCode.Branch => new BranchIns(input),
            OPCode.BranchIf => new BranchIfIns(input),
            OPCode.Else => new ElseIns(),
            OPCode.Return => new ReturnIns(),
            OPCode.Call => new CallIns(input),
            OPCode.CallIndirect => new CallIndirectIns(input),
            OPCode.End => new EndIns(),

            // Parametric
            OPCode.Drop => new DropIns(),

            // Numeric
            OPCode.ConstantInt32 => new ConstantInt32Ins(input),
            OPCode.ConstantInt64 => new ConstantInt64Ins(input),
            OPCode.ConstantFloat32 => new ConstantFloat32Ins(input),
            OPCode.EqualsZeroInt32 => new EqualsZeroInt32Ins(),
            OPCode.EqualsInt32 => new EqualsInt32Ins(),
            OPCode.AddInt32 => new AddInt32Ins(),
            OPCode.AndInt32 => new AndInt32Ins(),
            OPCode.OrInt32 => new OrInt32Ins(),
            OPCode.MultiplyInt32 => new MultiplyInt32Ins(),
            OPCode.NotEqualInt32 => new NotEqualInt32Ins(),
            OPCode.LessThanUInt32 => new LessThanUInt32Ins(),
            OPCode.GreaterThanUInt32 => new GreaterThanUInt32Ins(),
            OPCode.GreaterThanSInt32 => new GreaterThanSInt32Ins(),
            OPCode.ShiftLeftInt32 => new ShiftLeftInt32Ins(),
            OPCode.ShiftRightUInt32 => new ShiftRightUInt32Ins(),
            OPCode.Int32WrapInt64 => new Int32WrapInt64Ins(),
            OPCode.SubtractInt32 => new SubtractInt32Ins(),

            // Variable
            OPCode.GetLocal => new GetLocalIns(input),
            OPCode.SetLocal => new SetLocalIns(input),
            OPCode.TeeLocal => new TeeLocalIns(input),
            OPCode.GetGlobal => new GetGlobalIns(input),
            OPCode.SetGlobal => new SetGlobalIns(input),

            // Memory
            OPCode.LoadInt32 => new LoadInt32Ins(input),
            OPCode.LoadInt64 => new LoadInt64Ins(input),
            OPCode.LoadFloat32 => new LoadFloat32Ins(input),
            OPCode.LoadInt32_8S => new LoadInt328SIns(input),
            OPCode.StoreInt32 => new StoreInt32Ins(input),
            OPCode.StoreInt32_8 => new StoreInt328Ins(input),
            OPCode.StoreInt64 => new StoreInt64Ins(input),
            OPCode.MemoryGrow => new MemoryGrowIns(input),

            _ => throw new NotImplementedException()
        };
        public static WASMInstruction Create(WASMReader input) => Create((OPCode)input.ReadByte(), input);
    }
}