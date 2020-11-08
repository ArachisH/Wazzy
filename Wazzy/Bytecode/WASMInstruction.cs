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
            OPCode.ConstantI32 => new ConstantI32Ins(input),
            OPCode.ConstantI64 => new ConstantI64Ins(input),
            OPCode.ConstantF32 => new ConstantF32Ins(input),
            OPCode.ConstantF64 => new ConstantF64Ins(input),
            OPCode.EqualsZeroI32 => new EqualsZeroI32Ins(),
            OPCode.EqualsI32 => new EqualsI32Ins(),
            OPCode.AddI32 => new AddI32Ins(),
            OPCode.AndI32 => new AndI32Ins(),
            OPCode.OrI32 => new OrI32Ins(),
            OPCode.MultiplyI32 => new MultiplyI32Ins(),
            OPCode.NotEqualI32 => new NotEqualI32Ins(),
            OPCode.LessThanI32_U => new LessThanI32_UIns(),
            OPCode.GreaterThanI32_U => new GreaterThanI32_UIns(),
            OPCode.GreaterThanI32_S => new GreaterThanI32_SIns(),
            OPCode.ShiftLeftI32 => new ShiftLeftI32Ins(),
            OPCode.ShiftRightI32_U => new ShiftRightI32_UIns(),
            OPCode.WrapI64IntoI32 => new WrapI64IntoI32Ins(),
            OPCode.SubtractI32 => new SubtractI32Ins(),
            OPCode.ExtendI32_8S => new ExtendI32_8SIns(),
            OPCode.MultiplyF32 => new MultiplyF32Ins(),
            OPCode.AddF32 => new AddF32Ins(),
            OPCode.DivideUnsignedI64 => new DivideUnsignedI64Ins(),
            OPCode.LessThanOrZeroI32_S => new LessThanOrZeroI32_SIns(),
            OPCode.SubtractF32 => new SubtractF32Ins(),
            OPCode.XorI32 => new XorI32Ins(),
            OPCode.ExtendSignedI32IntoI64 => new ExtendSignedI32IntoI64Ins(),
            OPCode.AddI64 => new AddI64Ins(),
            OPCode.GreaterThanOrEqualI32_U => new GreaterThanOrEqualI32_UIns(),
            OPCode.LessThanOrEqualI32_U => new LessThanOrEqualI32_UIns(),
            OPCode.DivideSignedI32 => new DivideSignedI32Ins(),
            OPCode.GreaterThanF32 => new GreaterThanF32Ins(),
            OPCode.LessThanF32 => new LessThanF32Ins(),
            OPCode.ConvertSignedI32IntoF32 => new ConvertSignedI32IntoF32Ins(),
            OPCode.ReinterpretF32IntoI32 => new ReinterpretF32IntoI32Ins(),
            OPCode.ReinterpretI32IntoF32 => new ReinterpretI32IntoF32Ins(),
            OPCode.ShiftRightI64_U => new ShiftRightI64_UIns(),
            OPCode.ExtendUnsignedI32IntoI64 => new ExtendUnsignedI32IntoI64Ins(),
            OPCode.ShiftLeftI64 => new ShiftLeftI64Ins(),
            OPCode.AndI64 => new AndI64Ins(),
            OPCode.OrI64 => new OrI64Ins(),
            OPCode.SquareRootF32 => new SquareRootF32Ins(),
            OPCode.DivideF32 => new DivideF32Ins(),
            OPCode.ShiftRightI32_S => new ShiftRightI32_SIns(),
            OPCode.NotEqualF32 => new NotEqualF32Ins(),
            OPCode.AbsoluteF32 => new AbsoluteF32Ins(),
            OPCode.RemainderI32_U => new RemainderI32_UIns(),
            OPCode.RotateLeftI64 => new RotateLeftI64Ins(),
            OPCode.SubtractI64 => new SubtractI64Ins(),
            OPCode.ReinterpretI64IntoF32 => new ReinterpretI64IntoF32Ins(),

            // Variable
            OPCode.GetLocal => new GetLocalIns(input),
            OPCode.SetLocal => new SetLocalIns(input),
            OPCode.TeeLocal => new TeeLocalIns(input),
            OPCode.GetGlobal => new GetGlobalIns(input),
            OPCode.SetGlobal => new SetGlobalIns(input),

            // Memory
            OPCode.LoadI32 => new LoadI32Ins(input),
            OPCode.LoadI64 => new LoadI64Ins(input),
            OPCode.LoadI64_8S => new LoadI64_8SIns(input),
            OPCode.LoadF32 => new LoadF32Ins(input),
            OPCode.LoadI32_8S => new LoadI32_8SIns(input),
            OPCode.StoreI32 => new StoreI32Ins(input),
            OPCode.StoreI32_8 => new StoreI32_8Ins(input),
            OPCode.StoreI64 => new StoreI64Ins(input),
            OPCode.StoreF32 => new StoreF32Ins(input),
            OPCode.MemoryGrow => new MemoryGrowIns(input),
            OPCode.MemorySize => new MemorySizeIns(input),

            _ => throw new NotImplementedException()
        };
        public static WASMInstruction Create(WASMReader input) => Create((OPCode)input.ReadByte(), input);
    }
}