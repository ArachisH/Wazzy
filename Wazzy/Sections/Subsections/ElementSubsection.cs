using System.Collections.Generic;

using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class ElementSubsection
    {
        public int TableIndex { get; set; }
        public int[] FunctionTypeIndices { get; }

        public int Offset { get; }
        public List<WASMInstruction> Expression { get; set; }

        public ElementSubsection(WASMModule module)
        {
            TableIndex = module.Input.Read7BitEncodedInt();
            Expression = module.Input.ReadExpression();
            //Offset = (int)WASMMachine.Execute(Expression).Pop();
            FunctionTypeIndices = new int[module.Input.Read7BitEncodedInt()];
            for (int i = 0; i < FunctionTypeIndices.Length; i++)
            {
                FunctionTypeIndices[i] = module.Input.Read7BitEncodedInt();
            }
        }
    }
}