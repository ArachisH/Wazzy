
using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadI32_8UIns : MemoryInstruction
    {
        public LoadI32_8UIns()
            : base(OPCode.LoadI32_8U, true)
        { }
        public LoadI32_8UIns(ref WASMReader input)
            : base(OPCode.LoadI32_8U, input, true)
        { }
        public LoadI32_8UIns(int align, int offset)
            : base(OPCode.LoadI32_8U, align, offset)
        { }
    }
}