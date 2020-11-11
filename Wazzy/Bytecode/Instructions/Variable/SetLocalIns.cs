using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class SetLocalIns : WASMInstruction
    {
        public int Id { get; set; }

        public SetLocalIns(int id = 0)
            : base(OPCode.SetLocal)
        {
            Id = id;
        }
        public SetLocalIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Id);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(Id);
    }
}