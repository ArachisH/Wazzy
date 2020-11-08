﻿using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadI64_8SIns : MemoryInstruction
    {
        public LoadI64_8SIns()
            : base(OPCode.LoadI64_8S, true)
        { }
        public LoadI64_8SIns(WASMReader input)
            : base(OPCode.LoadI64_8S, input, true)
        { }
        public LoadI64_8SIns(int align, int offset)
            : base(OPCode.LoadI64_8S, align, offset)
        { }
    }
}