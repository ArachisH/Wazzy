using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadI32_8SIns : MemoryInstruction
    {
        public LoadI32_8SIns()
            : base(OPCode.LoadI32_8S, true)
        { }
        public LoadI32_8SIns(ref WASMReader input)
            : base(OPCode.LoadI32_8S, input, true)
        { }
        public LoadI32_8SIns(int align, int offset)
            : base(OPCode.LoadI32_8S, align, offset)
        { }
    }
}