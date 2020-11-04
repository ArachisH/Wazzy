using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public class MemoryGrowIns : WASMInstruction
    {
        public byte Index { get; }

        public MemoryGrowIns(WASMReader input)
            : base(OPCode.MemoryGrow)
        {
            Index = input.ReadByte();
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write(Index);
        }
    }
}