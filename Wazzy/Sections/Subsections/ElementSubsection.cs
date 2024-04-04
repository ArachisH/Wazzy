using Wazzy.IO;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections;

public sealed class ElementSubsection : WASMObject
{
    private readonly IFunctionOffsetProvider? _functionOffsetProvider;

    public uint TableIndex { get; set; }
    public List<WASMInstruction> Expression { get; }
    public List<uint> FunctionReferenceIndices { get; }

    public ElementSubsection(uint tableIndex = 0)
    {
        // TODO: Do not assume an active segment of Vector<func.refs>.
        // ElemKind should be populate in place of TableIndex.

        TableIndex = tableIndex;
        Expression = new List<WASMInstruction>(3);
        FunctionReferenceIndices = new List<uint>();
    }
    public ElementSubsection(ref WASMReader input, IFunctionOffsetProvider? functionOffsetProvider = null)
    {
        _functionOffsetProvider = functionOffsetProvider;

        TableIndex = input.ReadIntULEB128();
        Expression = input.ReadExpression();

        var indices = new uint[(int)input.ReadIntULEB128() + 1];
        for (int i = 1; i < indices.Length; i++)
        {
            indices[i] = input.ReadIntULEB128();
        }

        FunctionReferenceIndices = new List<uint>(indices);
    }

    public T EvaluateOffset<T>(WASMModule context)
    {
        return (T)WASMMachine.Execute(Expression, context).Pop();
    }

    public override int GetSize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size(TableIndex);
        foreach (WASMInstruction instruction in Expression)
        {
            size += instruction.GetSize();
        }

        size += WASMReader.GetULEB128Size((uint)FunctionReferenceIndices.Count - 1);
        for (int i = 1; i < FunctionReferenceIndices.Count; i++)
        {
            size += WASMReader.GetULEB128Size(FunctionReferenceIndices[i] + (uint)(_functionOffsetProvider?.FunctionOffset ?? 0));
        }
        return size;
    }
    public override void WriteTo(ref WASMWriter output)
    {
        output.WriteULEB128(TableIndex);
        foreach (WASMInstruction instruction in Expression)
        {
            instruction.WriteTo(ref output);
        }

        output.WriteULEB128((uint)FunctionReferenceIndices.Count - 1);
        for (int i = 1; i < FunctionReferenceIndices.Count; i++)
        {
            output.WriteULEB128(FunctionReferenceIndices[i] + (uint)(_functionOffsetProvider?.FunctionOffset ?? 0));
        }
    }
}