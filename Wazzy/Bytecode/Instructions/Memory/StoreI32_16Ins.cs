using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreI32_16Ins : MemoryInstruction
    {
        public StoreI32_16Ins()
            : base(OPCode.StoreI32_16, true)
        { }
        public StoreI32_16Ins(ref WASMReader input)
            : base(OPCode.StoreI32_16, input, true)
        { }
        public StoreI32_16Ins(int align, int offset)
            : base(OPCode.StoreI32_16, align, offset)
        { }
    }
}
