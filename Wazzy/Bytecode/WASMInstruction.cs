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

        public override int GetSize()
        {
            int size = 0;
            size += sizeof(byte);
            size += GetBodySize();
            return size;
        }
        protected virtual int GetBodySize()
        {
            return 0;
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.Write((byte)OP);
            WriteBodyTo(ref output);
        }
        protected virtual void WriteBodyTo(ref WASMWriter output)
        { }

        public static WASMInstruction Create(ref WASMReader input) => Create((OPCode)input.ReadByte(), ref input);
        public static WASMInstruction Create(OPCode op, ref WASMReader input) => op switch
        {
            // Control
            OPCode.Unreachable => new UnreachableIns(),
            OPCode.Nop => new NopIns(),
            OPCode.Block => new BlockIns(ref input),
            OPCode.Loop => new LoopIns(ref input),
            OPCode.If => new IfIns(ref input),
            OPCode.Branch => new BranchIns(ref input),
            OPCode.BranchIf => new BranchIfIns(ref input),
            OPCode.BranchTable => new BranchTableIns(ref input),
            OPCode.Else => new ElseIns(),
            OPCode.Return => new ReturnIns(),
            OPCode.Call => new CallIns(ref input),
            OPCode.CallIndirect => new CallIndirectIns(ref input),
            OPCode.End => new EndIns(),

            // Parametric
            OPCode.Drop => new DropIns(),
            OPCode.Select => new SelectIns(),

            // Numeric
            OPCode.ConstantI32 => new ConstantI32Ins(ref input),
            OPCode.ConstantI64 => new ConstantI64Ins(ref input),
            OPCode.ConstantF32 => new ConstantF32Ins(ref input),
            OPCode.ConstantF64 => new ConstantF64Ins(ref input),
            OPCode.EqualZeroI32 => new EqualZeroI32Ins(),
            OPCode.EqualI32 => new EqualI32Ins(),
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
            OPCode.DivideI64_U => new DivideI64_UIns(),
            OPCode.LessThanOrZeroI32_S => new LessThanOrZeroI32_SIns(),
            OPCode.SubtractF32 => new SubtractF32Ins(),
            OPCode.XorI32 => new XorI32Ins(),
            OPCode.ExtendI32IntoI64_S => new ExtendI32IntoI64_SIns(),
            OPCode.AddI64 => new AddI64Ins(),
            OPCode.GreaterThanOrEqualI32_U => new GreaterThanOrEqualI32_UIns(),
            OPCode.LessThanOrEqualI32_U => new LessThanOrEqualI32_UIns(),
            OPCode.DivideI32_S => new DivideI32_SIns(),
            OPCode.GreaterThanF32 => new GreaterThanF32Ins(),
            OPCode.LessThanF32 => new LessThanF32Ins(),
            OPCode.ConvertSignedI32IntoF32 => new ConvertSignedI32IntoF32Ins(),
            OPCode.ReinterpretF32IntoI32 => new ReinterpretF32IntoI32Ins(),
            OPCode.ReinterpretI32IntoF32 => new ReinterpretI32IntoF32Ins(),
            OPCode.ShiftRightI64_U => new ShiftRightI64_UIns(),
            OPCode.ExtendI32IntoI64_U => new ExtendI32IntoI64_UIns(),
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
            OPCode.CeilingF32 => new CeilingF32Ins(),
            OPCode.DivideI64_S => new DivideI64_SIns(),
            OPCode.DivideI32_U => new DivideI32_UIns(),
            OPCode.LessThanI32_S => new LessThanI32_SIns(),
            OPCode.GreaterThanOrEqualI32_S => new GreaterThanOrEqualI32_SIns(),
            OPCode.EqualF32 => new EqualF32Ins(),
            OPCode.GreaterThanOrEqualF32 => new GreaterThanOrEqualF32Ins(),
            OPCode.LessThanF64 => new LessThanF64Ins(),
            OPCode.PromoteF32IntoF64 => new PromoteF32IntoF64Ins(),
            OPCode.GreaterThanOrEqualF64 => new GreaterThanOrEqualF64Ins(),
            OPCode.AddF64 => new AddF64Ins(),
            OPCode.FloorF64 => new FloorF64Ins(),
            OPCode.SubtractF64 => new SubtractF64Ins(),
            OPCode.CeilingF64 => new CeilingF64Ins(),
            OPCode.DemoteF64IntoF32 => new DemoteF64IntoF32Ins(),
            OPCode.FloorF32 => new FloorF32Ins(),
            OPCode.LessThanOrEqualF32 => new LessThanOrEqualF32Ins(),
            OPCode.TruncateF32IntoI32_S => new TruncateF32IntoI32_SIns(),
            OPCode.ConvertI32IntoF32_U => new ConvertI32IntoF32_UIns(),
            OPCode.NotEqualF64 => new NotEqualF64Ins(),
            OPCode.MaxF64 => new MaxF64Ins(),
            OPCode.MinF64 => new MinF64Ins(),
            OPCode.NegateF32 => new NegateF32Ins(),

            // Variable
            OPCode.GetLocal => new GetLocalIns(ref input),
            OPCode.SetLocal => new SetLocalIns(ref input),
            OPCode.TeeLocal => new TeeLocalIns(ref input),
            OPCode.GetGlobal => new GetGlobalIns(ref input),
            OPCode.SetGlobal => new SetGlobalIns(ref input),

            // Memory
            OPCode.LoadI32 => new LoadI32Ins(ref input),
            OPCode.LoadI64 => new LoadI64Ins(ref input),
            OPCode.LoadI64_8S => new LoadI64_8SIns(ref input),
            OPCode.LoadI64_32U => new LoadI64_32UIns(ref input),
            OPCode.LoadF32 => new LoadF32Ins(ref input),
            OPCode.LoadI32_8S => new LoadI32_8SIns(ref input),
            OPCode.LoadI32_8U => new LoadI32_8UIns(ref input),
            OPCode.LoadF64 => new LoadF64Ins(ref input),
            OPCode.StoreI32 => new StoreI32Ins(ref input),
            OPCode.StoreI32_8 => new StoreI32_8Ins(ref input),
            OPCode.StoreI32_16=> new StoreI32_16Ins(ref input),
            OPCode.LoadI32_16S => new LoadI32_16SIns(ref input),
            OPCode.StoreI64 => new StoreI64Ins(ref input),
            OPCode.StoreF32 => new StoreF32Ins(ref input),
            OPCode.MemoryGrow => new MemoryGrowIns(ref input),
            OPCode.MemorySize => new MemorySizeIns(ref input),

            _ => throw new NotImplementedException($"This instruction has not yet been implemented or does not exist in the specification. {op}(0x{(byte)op:X2})")
        };
    }
}