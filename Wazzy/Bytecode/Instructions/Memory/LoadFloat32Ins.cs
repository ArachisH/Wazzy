using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class LoadFloat32Ins : MemoryInstruction
    {
        public LoadFloat32Ins()
            : base(OPCode.LoadFloat32, true)
        { }
        public LoadFloat32Ins(WASMReader input)
            : base(OPCode.LoadFloat32, input, true)
        { }
        public LoadFloat32Ins(int align, int offset)
            : base(OPCode.LoadFloat32, align, offset)
        { }
    }
}