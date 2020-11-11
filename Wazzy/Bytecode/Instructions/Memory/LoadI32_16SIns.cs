using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadI32_16SIns : MemoryInstruction
    {
        public LoadI32_16SIns()
            : base(OPCode.LoadI32_16S, true)
        { }
        public LoadI32_16SIns(ref WASMReader input)
            : base(OPCode.LoadI32_16S, input, true)
        { }
        public LoadI32_16SIns(int align, int offset)
            : base(OPCode.LoadI32_16S, align, offset)
        { }
    }
}