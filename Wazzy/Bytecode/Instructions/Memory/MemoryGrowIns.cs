using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class MemoryGrowIns : MemoryInstruction
    {
        public byte Index { get; set; }

        public MemoryGrowIns(byte index = 0)
            : base(OPCode.MemoryGrow, false)
        {
            Index = index;
        }
        public MemoryGrowIns(WASMReader input)
            : this(input.ReadByte())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write(Index);
        }
    }
}