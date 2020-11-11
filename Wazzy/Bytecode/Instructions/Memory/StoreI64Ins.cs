using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreI64Ins : MemoryInstruction
    {
        public StoreI64Ins()
            : base(OPCode.StoreI64, true)
        { }
        public StoreI64Ins(ref WASMReader input)
            : base(OPCode.StoreI64, input, true)
        { }
        public StoreI64Ins(int align, int offset)
            : base(OPCode.StoreI64, align, offset)
        { }
    }
}