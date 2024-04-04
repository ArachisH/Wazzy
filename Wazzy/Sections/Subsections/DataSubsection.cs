using Wazzy.IO;
using Wazzy.Bytecode;
using Wazzy.Bytecode.Instructions.Control;
using Wazzy.Bytecode.Instructions.Numeric;

namespace Wazzy.Sections.Subsections;

public sealed class DataSubsection : WASMObject
{
    public uint MemoryIndex { get; }
    public byte[] Package { get; set; }
    public List<WASMInstruction> Expression { get; }

    public DataSubsection(ref WASMReader input)
    {
        MemoryIndex = input.ReadIntULEB128();
        Expression = input.ReadExpression();
        Package = new byte[input.ReadIntULEB128()];
        input.ReadBytes(Package);
    }
    public DataSubsection(int offset, byte[] package, uint memoryIndex = 0)
    {
        Package = package;
        Expression = new List<WASMInstruction>(2)
            {
                new ConstantI32Ins(offset),
                new EndIns()
            };
        MemoryIndex = memoryIndex;
    }

    public T EvaluateOffset<T>(WASMModule context)
    {
        return (T)WASMMachine.Execute(Expression, context).Pop();
    }

    public override int GetSize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size(MemoryIndex);
        foreach (WASMInstruction instruction in Expression)
        {
            size += instruction.GetSize();
        }
        size += WASMReader.GetULEB128Size((uint)Package.Length);
        size += Package.Length;
        return size;
    }
    public override void WriteTo(ref WASMWriter output)
    {
        output.WriteULEB128(MemoryIndex);
        foreach (WASMInstruction instruction in Expression)
        {
            instruction.WriteTo(ref output);
        }
        output.WriteULEB128((uint)Package.Length);
        output.Write(Package);
    }
}