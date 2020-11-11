using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class CallIns : WASMInstruction
    {
        public int FunctionIndex { get; set; }

        public CallIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }
        public CallIns(int functionIndex = 0)
            : base(OPCode.Call)
        {
            FunctionIndex = functionIndex;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(FunctionIndex);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(FunctionIndex);
    }
}