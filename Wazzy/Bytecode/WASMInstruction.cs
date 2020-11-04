using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode.Instructions.Memory;
using Wazzy.Bytecode.Instructions.Numeric;
using Wazzy.Bytecode.Instructions.Control;
using Wazzy.Bytecode.Instructions.Variable;

namespace Wazzy.Bytecode
{
    public abstract class WASMInstruction : WASMObject
    {
        public OPCode OP { get; }

        public WASMInstruction(OPCode op)
        {
            OP = op;
        }

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
            OPCode.If => new IfIns(input),
            OPCode.End => new EndIns(),

            // Numeric
            OPCode.ConstantInt32 => new ConstantInt32Ins(input),
            /* Zero Immediates */
            OPCode.AddInt32 => new AddInt32Ins(),
            OPCode.AndInt32 => new AndInt32Ins(),
            OPCode.EqualsZeroInt32 => new EqualsZeroInt32Ins(),

            // Variable
            OPCode.GetLocal => new GetLocalIns(input),
            OPCode.GetGlobal => new GetGlobalIns(input),
            OPCode.SetGlobal => new SetGlobalIns(input),

            // Memory
            OPCode.MemoryGrow => new MemoryGrowIns(input),

            _ => null,
        };
        public static WASMInstruction Create(WASMReader input) => Create((OPCode)input.ReadByte(), input);
    }
}