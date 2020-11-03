using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode.Instructions;
using Wazzy.Bytecode.Instructions.Numeric;
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

        public static WASMInstruction Create(WASMReader input)
        {
            var op = (OPCode)input.ReadByte();
            return op switch
            {
                // Control
                OPCode.End => new EndIns(),

                // Numeric
                OPCode.ConstantInt32 => new ConstantInt32Ins(input),

                // Variable
                OPCode.GetGlobal => new GetGlobalIns(input),

                _ => null,
            };
        }
    }
}