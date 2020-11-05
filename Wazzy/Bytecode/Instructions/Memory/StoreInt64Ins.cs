using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreInt64Ins : MemoryInstruction
    {
        public StoreInt64Ins()
            : base(OPCode.StoreInt64, true)
        { }
        public StoreInt64Ins(WASMReader input)
            : base(OPCode.StoreInt64, input, true)
        { }
        public StoreInt64Ins(int align, int offset)
            : base(OPCode.StoreInt64, align, offset)
        { }
    }
}