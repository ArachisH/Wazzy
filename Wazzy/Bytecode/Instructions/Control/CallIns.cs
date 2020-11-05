using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class CallIns : WASMInstruction
    {
        public int FunctionIndex { get; set; }

        public CallIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }
        public CallIns(int functionIndex = 0)
            : base(OPCode.Call)
        {
            FunctionIndex = functionIndex;
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(FunctionIndex);
        }
    }
}