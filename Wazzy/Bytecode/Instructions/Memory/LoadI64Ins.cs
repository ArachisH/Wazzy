using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadI64Ins : MemoryInstruction
    {
        public LoadI64Ins()
            : base(OPCode.LoadI64, true)
        { }
        public LoadI64Ins(ref WASMReader input)
            : base(OPCode.LoadI64, input, true)
        { }
        public LoadI64Ins(int align, int offset)
            : base(OPCode.LoadI64, align, offset)
        { }
    }
}