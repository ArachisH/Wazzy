using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Variable
{
    public class GetGlobalIns : WASMInstruction
    {
        public int Id { get; }

        public GetGlobalIns(WASMReader input)
            : base(OPCode.GetGlobal)
        {
            Id = input.Read7BitEncodedInt();
        }

        public override void Execute(Stack<object> stack, WASMModule context)
        {
            WASMMachine.Execute(context.GlobalSec[Id].Expression, context, stack);
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(Id);
        }
    }
}