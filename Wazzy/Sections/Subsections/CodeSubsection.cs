using Wazzy.IO;
using Wazzy.Types;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections;

public sealed class CodeSubsection : WASMObject
{
    private readonly IFunctionOffsetProvider _functionOffsetProvider;

    public List<Local> Locals { get; }
    public byte[] Bytecode { get; set; }

    public CodeSubsection(ref WASMReader input, IFunctionOffsetProvider functionOffsetProvider)
    {
        _functionOffsetProvider = functionOffsetProvider;

        int funcSize = (int)input.ReadIntULEB128();
        int funcEnd = input.Position + funcSize;

        Locals = new List<Local>((int)input.ReadIntULEB128());
        for (int i = 0; i < Locals.Capacity; i++)
        {
            Locals.Add(new Local(ref input));
        }

        Bytecode = new byte[funcEnd - input.Position];
        input.ReadBytes(Bytecode);

        if (funcEnd != input.Position)
        {
            throw new Exception("Malformed subsection, since the expected ending position did not match the actual ending position.");
        }
    }

    public List<WASMInstruction> Parse() => new WASMReader(Bytecode).ReadExpression(_functionOffsetProvider);

    public override int GetSize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Locals.Count);
        foreach (Local local in Locals)
        {
            size += local.GetSize();
        }
        size += Bytecode.Length;
        size += WASMReader.GetULEB128Size((uint)size);
        return size;
    }
    public override void WriteTo(ref WASMWriter output)
    {
        int funcSize = 0;
        funcSize += WASMReader.GetULEB128Size((uint)Locals.Count);
        foreach (Local local in Locals)
        {
            funcSize += local.GetSize();
        }
        funcSize += Bytecode.Length;

        output.WriteULEB128((uint)funcSize);
        output.WriteULEB128((uint)Locals.Count);
        foreach (Local local in Locals)
        {
            local.WriteTo(ref output);
        }
        output.Write(Bytecode);
    }
}