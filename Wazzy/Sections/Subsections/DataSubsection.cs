using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class DataSubsection : WASMObject
    {
        public int Offset { get; }
        public int MemoryIndex { get; }
        public byte[] Package { get; set; }
        public List<WASMInstruction> Expression { get; }

        public DataSubsection(WASMModule module)
        {
            MemoryIndex = module.Input.Read7BitEncodedInt();
            Expression = module.Input.ReadExpression();
            Offset = (int)WASMMachine.Execute(Expression, module).Pop();
            Package = module.Input.ReadBytes(module.Input.Read7BitEncodedInt());
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(MemoryIndex);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(output);
            }
            output.Write7BitEncodedInt(Package.Length);
            output.Write(Package);
        }
    }
}