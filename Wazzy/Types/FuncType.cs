using System.Diagnostics;

using Wazzy.IO;

namespace Wazzy.Types;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class FuncType : WASMType
{
    internal string DebuggerDisplay
    {
        get
        {
            string results = ResultTypes.Count switch
            {
                0 => "void",
                1 => ResultTypes[0].Name,

                _ => $"({string.Join(", ", ResultTypes.Select(t => t.Name))})"
            };

            string signature = results + " Function(";
            for (int i = 0; i < ParameterTypes.Count; i++)
            {
                signature += $"{ParameterTypes[i].Name} local_{i}, ";
            }
            return signature.Substring(0, signature.Length - ((ParameterTypes.Count > 0 ? 1 : 0) * 2)) + ")";
        }
    }

    public List<Type> ResultTypes { get; }
    public List<Type> ParameterTypes { get; }

    public FuncType(ref WASMReader input)
    {
        ParameterTypes = new List<Type>((int)input.ReadIntULEB128());
        for (int i = 0; i < ParameterTypes.Capacity; i++)
        {
            ParameterTypes.Add(input.ReadValueType());
        }

        ResultTypes = new List<Type>((int)input.ReadIntULEB128());
        for (int i = 0; i < ResultTypes.Capacity; i++)
        {
            ResultTypes.Add(input.ReadValueType());
        }
    }
    public FuncType(IList<Type> parameterTypes, IList<Type> resultTypes)
    {
        ResultTypes = new List<Type>(resultTypes ?? Array.Empty<Type>());
        ParameterTypes = new List<Type>(parameterTypes ?? Array.Empty<Type>());
    }

    public override int GetSize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)ParameterTypes.Count);
        size += ParameterTypes.Count * sizeof(byte);
        size += WASMReader.GetULEB128Size((uint)ResultTypes.Count);
        size += ResultTypes.Count * sizeof(byte);
        return size;
    }
    public override void WriteTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)ParameterTypes.Count);
        foreach (Type parameterType in ParameterTypes)
        {
            output.Write(parameterType);
        }

        output.WriteULEB128((uint)ResultTypes.Count);
        foreach (Type resultType in ResultTypes)
        {
            output.Write(resultType);
        }
    }
}