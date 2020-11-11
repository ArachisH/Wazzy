using System;
using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class IfIns : WASMInstruction
    {
        public int BlockId { get; set; }
        public Type BlockType { get; private set; }

        public List<WASMInstruction> Expression { get; }
        public List<WASMInstruction> ElseExpression { get; }

        public bool HasElseExpression => ElseExpression?.Count > 0;

        public IfIns()
            : base(OPCode.If)
        {
            Expression = new List<WASMInstruction>();
            ElseExpression = new List<WASMInstruction>();
        }
        public IfIns(ref WASMReader input)
            : base(OPCode.If)
        {
            BlockId = input.ReadIntLEB128();
            if (WASMType.IsSupportedType(BlockId))
            {
                BlockType = WASMType.GetType((byte)BlockId);
            }
            else if (BlockId == 0x40) BlockType = typeof(void);

            Expression = input.ReadExpression(OPCode.Else);
            if (Expression[^1].OP == OPCode.Else)
            {
                ElseExpression = input.ReadExpression();
                Expression.RemoveAt(Expression.Count - 1);
            }
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(BlockId);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(ref output);
            }
            if (ElseExpression.Count == 0) return;

            output.Write((byte)OPCode.Else);
            foreach (WASMInstruction instruction in ElseExpression)
            {
                instruction.WriteTo(ref output);
            }
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(BlockId);
            foreach (WASMInstruction instruction in Expression)
            {
                size += instruction.GetSize();
            }

            if (HasElseExpression)
            {
                foreach (WASMInstruction instruction in ElseExpression)
                {
                    size += instruction.GetSize();
                }
            }
            return size;
        }
    }
}