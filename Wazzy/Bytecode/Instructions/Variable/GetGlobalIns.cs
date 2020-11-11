using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class GetGlobalIns : WASMInstruction
    {
        public int Id { get; set; }

        public GetGlobalIns(int id = 0)
            : base(OPCode.GetGlobal)
        {
            Id = id;
        }
        public GetGlobalIns(ref WASMReader input)
            : this(input.ReadIntLEB128())
        { }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            WASMMachine.Execute(context.GlobalSec[Id].Expression, context, stack);
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(Id);
        }

        protected override int GetBodySize() => WASMReader.GetLEB128Size(Id);
    }
}