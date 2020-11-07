using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class StoreFloat32Ins : MemoryInstruction
    {
        public StoreFloat32Ins()
            : base(OPCode.StoreFloat32, true)
        { }
        public StoreFloat32Ins(WASMReader input)
            : base(OPCode.StoreFloat32, input, true)
        { }
        public StoreFloat32Ins(int align, int offset)
            : base(OPCode.StoreFloat32, align, offset)
        { }
    }
}