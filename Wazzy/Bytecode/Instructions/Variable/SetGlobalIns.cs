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
        public SetGlobalIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}