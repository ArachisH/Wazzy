﻿using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class GetLocalIns : WASMInstruction
    {
        public int Id { get; set; }

        public GetLocalIns(int id = 0)
            : base(OPCode.GetLocal)
        {
            Id = id;
        }
        public GetLocalIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}