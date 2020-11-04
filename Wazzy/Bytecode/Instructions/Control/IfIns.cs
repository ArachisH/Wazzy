using System;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class IfIns : WASMInstruction
    {
        public IfIns(WASMReader input)
            : base(OPCode.If)
        {
            throw new NotImplementedException();
        }
    }
}