using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class TeeLocalIns : WASMInstruction
    {
        public int Id { get; set; }

        public TeeLocalIns(int id = 0)
            : base(OPCode.TeeLocal)
        {
            Id = id;
        }
        public TeeLocalIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Id);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(Id);
    }
}