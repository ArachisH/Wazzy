using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class MemorySizeIns : MemoryInstruction
    {
        public byte Index { get; set; }

        public MemorySizeIns(byte index = 0)
            : base(OPCode.MemorySize, false)
        {
            Index = index;
        }
        public MemorySizeIns(ref WASMReader input)
            : this(input.ReadByte())
        { }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.Write(Index);
        }

        protected override int GetBodySize() => sizeof(byte);
    }
}