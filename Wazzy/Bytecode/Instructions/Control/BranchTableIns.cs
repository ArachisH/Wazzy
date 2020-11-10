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
        public BranchTableIns(WASMReader input)
            : this()
        {
            LabelIndices.Capacity = input.Read7BitEncodedInt();
            for (int i = 0; i < LabelIndices.Capacity; i++)
            {
                LabelIndices.Add(input.Read7BitEncodedInt());
            }
            LabelIndex = input.Read7BitEncodedInt();
        }

        protected override void WriteBodyTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(LabelIndices.Count);
            foreach (int labelIndex in LabelIndices)
            {
                output.Write7BitEncodedInt(labelIndex);
            }
            output.Write7BitEncodedInt(LabelIndex);
        }
    }
}