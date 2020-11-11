using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class SetGlobalIns : WASMInstruction
    {
        public int Id { get; set; }

        public SetGlobalIns(int id = 0)
            : base(OPCode.SetGlobal)
        {
            Id = id;
        }
        public SetGlobalIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Id);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(Id);
    }
}