using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadInt648SIns : MemoryInstruction
    {
        public LoadInt648SIns()
            : base(OPCode.LoadInt64_8S, true)
        { }
        public LoadInt648SIns(WASMReader input)
            : base(OPCode.LoadInt64_8S, input, true)
        { }
        public LoadInt648SIns(int align, int offset)
            : base(OPCode.LoadInt64_8S, align, offset)
        { }
    }
}