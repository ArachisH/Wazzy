using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreInt328Ins : MemoryInstruction
    {
        public StoreInt328Ins()
            : base(OPCode.StoreInt32_8, true)
        { }
        public StoreInt328Ins(WASMReader input)
            : base(OPCode.StoreInt32_8, input, true)
        { }
        public StoreInt328Ins(int align, int offset)
            : base(OPCode.StoreInt32_8, align, offset)
        { }
    }
}