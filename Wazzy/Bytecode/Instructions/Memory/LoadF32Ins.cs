using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadF32Ins : MemoryInstruction
    {
        public LoadF32Ins()
            : base(OPCode.LoadF32, true)
        { }
        public LoadF32Ins(ref WASMReader input)
            : base(OPCode.LoadF32, input, true)
        { }
        public LoadF32Ins(int align, int offset)
            : base(OPCode.LoadF32, align, offset)
        { }
    }
}