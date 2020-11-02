using System.Collections.Generic;

using Wazzy.Types;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class GlobalSubsection
    {
        public GlobalType Info { get; set; }
        public List<WASMInstruction> Expression { get; set; }

        public GlobalSubsection(WASMModule module)
        {
            Info = new GlobalType(module);
            Expression = module.Input.ReadExpression();
        }
    }
}