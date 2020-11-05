﻿using System;
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

        public IfIns()
            : base(OPCode.If)
        {
            Expression = new List<WASMInstruction>();
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
            else System.Diagnostics.Debugger.Break();

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