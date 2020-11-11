using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Bytecode;
using Wazzy.Bytecode.Instructions.Control;
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
                new ConstantI32Ins(offset),
                new EndIns()
            };
        }
        public DataSubsection(WASMModule module, ref WASMReader input)
        {
            MemoryIndex = input.ReadIntLEB128();
            Expression = input.ReadExpression();
            Offset = (int)WASMMachine.Execute(Expression, module).Pop();
            
            Package = new byte[input.ReadIntULEB128()];
            input.ReadBytes(Package);
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.WriteLEB128(MemoryIndex);
            foreach (WASMInstruction instruction in Expression)
            {
                instruction.WriteTo(ref output);
            }
            output.WriteULEB128((uint)Package.Length);
            output.Write(Package);
        }

        public override int GetSize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(MemoryIndex);
            foreach (WASMInstruction instruction in Expression)
            {
                size += instruction.GetSize();
            }
            size += WASMReader.GetULEB128Size((uint)Package.Length);
            size += Package.Length;
            return size;
        }
    }
}