using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadInt32Ins : MemoryInstruction
    {
        public LoadInt32Ins()
            : base(OPCode.LoadInt32, true)
        { }
        public LoadInt32Ins(WASMReader input)
            : base(OPCode.LoadInt32, input, true)
        { }
        public LoadInt32Ins(int align, int offset)
            : base(OPCode.LoadInt32, align, offset)
        { }
    }
}