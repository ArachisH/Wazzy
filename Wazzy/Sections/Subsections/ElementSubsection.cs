using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class ElementSubsection : WASMObject
    {
        public int TableIndex { get; set; }
        public int[] FunctionTypeIndices { get; }

        public int Offset { get; }
        public List<WASMInstruction> Expression { get; set; }

        public ElementSubsection(WASMModule module)
        {
            TableIndex = module.Input.Read7BitEncodedInt();
            Expression = module.Input.ReadExpression();
            Offset = (int)WASMMachine.Execute(Expression, module).Pop();
            FunctionTypeIndices = new int[module.Input.Read7BitEncodedInt()];
            for (int i = 0; i < FunctionTypeIndices.Length; i++)
            {
                FunctionTypeIndices[i] = module.Input.Read7BitEncodedInt();
            }
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(TableIndex);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(output);
            }

            output.Write7BitEncodedInt(FunctionTypeIndices.Length);
            foreach (int functionTypeIndex in FunctionTypeIndices)
            {
                output.Write7BitEncodedInt(functionTypeIndex);
            }
        }
    }
}