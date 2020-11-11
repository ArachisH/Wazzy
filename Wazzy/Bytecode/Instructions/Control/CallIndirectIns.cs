using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class CallIndirectIns : WASMInstruction
    {
        public int TypeIndex { get; set; }

        public CallIndirectIns(int typeIndex)
            : base(OPCode.CallIndirect)
        {
            TypeIndex = typeIndex;
        }
        public CallIndirectIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        {
            /* In future versions of WebAssembly, the zero byte occurring in the encoding of the call_indirect instruction may be used to index additional tables. */
            input.ReadByte();
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(TypeIndex);
            output.Write((byte)0);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(TypeIndex) + sizeof(byte);
    }
}