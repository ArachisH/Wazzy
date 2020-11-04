using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class GetLocalIns : WASMInstruction
    {
        public int Id { get; set; }

        public GetLocalIns(WASMReader input)
            : base(OPCode.GetLocal)
        {
            Id = input.Read7BitEncodedInt();
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}