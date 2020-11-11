using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control
{
    public class BranchTableIns : WASMInstruction
    {
        public int LabelIndex { get; set; }
        public List<int> LabelIndices { get; }

        public BranchTableIns()
            : base(OPCode.BranchTable)
        {
            LabelIndices = new List<int>();
        }
        public BranchTableIns(ref WASMReader input)
            : this()
        {
            LabelIndices.Capacity = input.ReadIntLEB128();
            for (int i = 0; i < LabelIndices.Capacity; i++)
            {
                LabelIndices.Add(input.ReadIntLEB128());
            }
            LabelIndex = input.ReadIntLEB128();
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(LabelIndices.Count);
            foreach (int labelIndex in LabelIndices)
            {
                output.WriteLEB128(labelIndex);
            }
            output.WriteLEB128(LabelIndex);
        }

        protected override int GetBodySize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(LabelIndices.Count);
            foreach (int labelIndex in LabelIndices)
            {
                size += WASMReader.GetLEB128Size(labelIndex);
            }
            size += WASMReader.GetLEB128Size(LabelIndex);
            return size;
        }
    }
}