using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Memory
{
    public abstract class MemoryInstruction : WASMInstruction
    {
        private readonly bool _hasMemoryArguments;

        public int Align { get; set; }
        public int Offset { get; set; }

        public MemoryInstruction(OPCode op, int align, int offset)
            : this(op, true)
        {
            Align = align;
            Offset = offset;
        }
        public MemoryInstruction(OPCode op, bool hasMemoryArguments)
            : base(op)
        {
            _hasMemoryArguments = hasMemoryArguments;
        }
        protected MemoryInstruction(OPCode op, WASMReader input, bool hasMemoryArguments)
            : this(op, hasMemoryArguments)
        {
            if (_hasMemoryArguments = hasMemoryArguments)
            {
                Align = input.Read7BitEncodedInt();
                Offset = input.Read7BitEncodedInt();
            }
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            if (_hasMemoryArguments)
            {
                output.Write7BitEncodedInt(Align);
                output.Write7BitEncodedInt(Offset);
            }
        }
    }
}