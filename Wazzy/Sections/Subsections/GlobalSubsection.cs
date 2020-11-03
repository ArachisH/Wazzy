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

        public GlobalSubsection(WASMModule module)
        {
            Info = new GlobalType(module);
            Expression = module.Input.ReadExpression();
        }

        public override void WriteTo(WASMWriter output)
        {
            Info.WriteTo(output);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(output);
            }
        }
    }
}