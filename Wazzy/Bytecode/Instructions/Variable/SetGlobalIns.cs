using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class SetGlobalIns : WASMInstruction
    {
        public int Id { get; set; }

        public SetGlobalIns(WASMReader input)
            : base(OPCode.SetGlobal)
        {
            Id = input.Read7BitEncodedInt();
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}