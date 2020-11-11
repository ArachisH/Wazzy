using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadI32Ins : MemoryInstruction
    {
        public LoadI32Ins()
            : base(OPCode.LoadI32, true)
        { }
        public LoadI32Ins(ref WASMReader input)
            : base(OPCode.LoadI32, input, true)
        { }
        public LoadI32Ins(int align, int offset)
            : base(OPCode.LoadI32, align, offset)
        { }
    }
}