using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadF64Ins : MemoryInstruction
    {
        public LoadF64Ins()
            : base(OPCode.LoadF64, true)
        { }
        public LoadF64Ins(ref WASMReader input)
            : base(OPCode.LoadF64, input, true)
        { }
        public LoadF64Ins(int align, int offset)
            : base(OPCode.LoadF64, align, offset)
        { }
    }
}