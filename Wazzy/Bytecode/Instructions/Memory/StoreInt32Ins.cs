using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreInt32Ins : MemoryInstruction
    {
        public StoreInt32Ins(WASMReader input)
            : base(OPCode.StoreInt32, input, true)
        { }
        public StoreInt32Ins(int align, int offset)
            : base(OPCode.StoreInt32, align, offset)
        { }
    }
}