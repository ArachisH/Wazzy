using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode;
using Wazzy.Bytecode.Instructions;
using Wazzy.Bytecode.Instructions.Numeric;

namespace Wazzy.Sections.Subsections
{
    public class DataSubsection : WASMObject
    {
        public int Offset { get; }
        public int MemoryIndex { get; }
        public byte[] Package { get; set; }
        public List<WASMInstruction> Expression { get; }

        public DataSubsection(int offset, byte[] package)
        {
            Offset = offset;
            Package = package;
            Expression = new List<WASMInstruction>()
            {
                new ConstantInt32Ins(offset),
                new EndIns()
            };
        }
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