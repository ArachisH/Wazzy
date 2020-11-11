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

        public ElementSubsection(WASMModule module, ref WASMReader input)
        {
            TableIndex = input.ReadIntLEB128();
            Expression = input.ReadExpression();
            Offset = (int)WASMMachine.Execute(Expression, module).Pop();
            FunctionTypeIndices = new int[input.ReadIntLEB128()];
            for (int i = 0; i < FunctionTypeIndices.Length; i++)
            {
                FunctionTypeIndices[i] = input.ReadIntLEB128();
            }
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.WriteLEB128(TableIndex);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(ref output);
            }

            output.WriteLEB128(FunctionTypeIndices.Length);
            foreach (int functionTypeIndex in FunctionTypeIndices)
            {
                output.WriteLEB128(functionTypeIndex);
            }
        }

        public override int GetSize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(TableIndex);
            foreach (WASMInstruction instruction in Expression)
            {
                size += instruction.GetSize();
            }
            
            size += WASMReader.GetLEB128Size(FunctionTypeIndices.Length);
            foreach (int functionTypeIndex in FunctionTypeIndices)
            {
                size += WASMReader.GetLEB128Size(functionTypeIndex);
            }
            return size;
        }
    }
}