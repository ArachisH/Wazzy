using System;
using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BlockIns : WASMInstruction
    {
        public int BlockId { get; set; }
        public Type BlockType { get; private set; }
        public List<WASMInstruction> Expression { get; }

        public BlockIns()
            : base(OPCode.Block)
        {
            Expression = new List<WASMInstruction>();
        }
        public BlockIns(WASMReader input)
            : base(OPCode.Block)
        {
            BlockId = input.Read7BitEncodedInt();
            if (WASMType.IsSupportedType(BlockId))
            {
                BlockType = WASMType.GetType(BlockId);
            }
            else if (BlockId == 0x40) BlockType = typeof(void);
            Expression = input.ReadExpression();
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(BlockId);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(output);
            }
        }
    }
}