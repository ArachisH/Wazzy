using System;
using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class LoopIns : WASMInstruction
    {
        public int BlockId { get; set; }
        public Type BlockType { get; private set; }
        public List<WASMInstruction> Expression { get; }

        public LoopIns()
            : base(OPCode.Loop)
        {
            Expression = new List<WASMInstruction>();
        }
        public LoopIns(ref WASMReader input)
            : base(OPCode.Loop)
        {
            BlockId = input.ReadIntLEB128();
            if (WASMType.IsSupportedType(BlockId))
            {
                BlockType = WASMType.GetType(BlockId);
            }
            else if (BlockId == 0x40) BlockType = typeof(void);
            Expression = input.ReadExpression();
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(BlockId);
            foreach (WASMInstruction instruction in Expression)
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
            return size;
        }
    }
}