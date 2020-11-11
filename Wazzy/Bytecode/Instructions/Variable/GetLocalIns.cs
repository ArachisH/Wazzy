using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class GetLocalIns : WASMInstruction
    {
        public int Id { get; set; }

        public GetLocalIns(int id = 0)
            : base(OPCode.GetLocal)
        {
            Id = id;
        }
        public GetLocalIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Id);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(Id);
    }
}