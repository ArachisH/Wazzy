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
        public CallIndirectIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        {
            /* In future versions of WebAssembly, the zero byte occurring in the encoding of the call_indirect instruction may be used to index additional tables. */
            input.ReadByte();
        }
    }
}