using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Types;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class GlobalSubsection : WASMObject
    {
        public GlobalType Info { get; set; }
        public List<WASMInstruction> Expression { get; set; }

        public GlobalSubsection(ref WASMReader input)
        {
            Info = new GlobalType(ref input);
            Expression = input.ReadExpression();
        }

        public override void WriteTo(ref WASMWriter output)
        {
            Info.WriteTo(ref output);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(ref output);
            }
        }

        public override int GetSize()
        {
            int size = 0;
            size += Info.GetSize();
            foreach (WASMInstruction instruction in Expression)
            {
                size += instruction.GetSize();
            }
            return size;
        }
    }
}