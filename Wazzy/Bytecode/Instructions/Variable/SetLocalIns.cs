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
        public SetLocalIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}