using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreF32Ins : MemoryInstruction
    {
        public StoreF32Ins()
            : base(OPCode.StoreF32, true)
        { }
        public StoreF32Ins(ref WASMReader input)
            : base(OPCode.StoreF32, input, true)
        { }
        public StoreF32Ins(int align, int offset)
            : base(OPCode.StoreF32, align, offset)
        { }
    }
}