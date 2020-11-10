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
        public IfIns(WASMReader input)
            : base(OPCode.If)
        {
            BlockId = input.Read7BitEncodedInt();
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

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(BlockId);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(output);
            }
            if (ElseExpression.Count == 0) return;

            output.Write((byte)OPCode.Else);
            foreach (WASMInstruction instruction in ElseExpression)
            {
                instruction.WriteTo(output);
            }
        }
    }
}