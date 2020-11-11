using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreI32Ins : MemoryInstruction
    {
        public StoreI32Ins(ref WASMReader input)
            : base(OPCode.StoreI32, input, true)
        { }
        public StoreI32Ins(int align, int offset)
            : base(OPCode.StoreI32, align, offset)
        { }
    }
}