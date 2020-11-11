using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreI32_8Ins : MemoryInstruction
    {
        public StoreI32_8Ins()
            : base(OPCode.StoreI32_8, true)
        { }
        public StoreI32_8Ins(ref WASMReader input)
            : base(OPCode.StoreI32_8, input, true)
        { }
        public StoreI32_8Ins(int align, int offset)
            : base(OPCode.StoreI32_8, align, offset)
        { }
    }
}