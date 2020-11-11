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
                Align = input.ReadIntLEB128();
                Offset = input.ReadIntLEB128();
            }
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            if (_hasMemoryArguments)
            {
                output.WriteLEB128(Align);
                output.WriteLEB128(Offset);
            }
        }

        protected override int GetBodySize()
        {
            return _hasMemoryArguments ? 
                WASMReader.GetLEB128Size(Align) + WASMReader.GetLEB128Size(Offset) : 0;
        }
    }
}