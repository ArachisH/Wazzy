using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadInt64Ins : MemoryInstruction
    {
        public LoadInt64Ins()
            : base(OPCode.LoadInt64, true)
        { }
        public LoadInt64Ins(WASMReader input)
            : base(OPCode.LoadInt64, input, true)
        { }
        public LoadInt64Ins(int align, int offset)
            : base(OPCode.LoadInt64, align, offset)
        { }
    }
}