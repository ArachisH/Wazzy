using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadInt328SIns : MemoryInstruction
    {
        public LoadInt328SIns()
            : base(OPCode.LoadInt32_8S, true)
        { }
        public LoadInt328SIns(WASMReader input)
            : base(OPCode.LoadInt32_8S, input, true)
        { }
        public LoadInt328SIns(int align, int offset)
            : base(OPCode.LoadInt32_8S, align, offset)
        { }
    }
}