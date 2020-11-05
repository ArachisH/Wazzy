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
        public TeeLocalIns(WASMReader input)
            : this(input.Read7BitEncodedInt())
        { }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}