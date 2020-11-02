using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Sections.Subsections;

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
            // TODO: Implement instruction execution
            if (Id < context.GlobalSec.Count)
            {
                WASMMachine.Execute(context.GlobalSec[Id].Expression, stack);
                if (stack.Peek() is GlobalSubsection globalSubsec) // ?!?!
                { }
            }
        }
    }
}