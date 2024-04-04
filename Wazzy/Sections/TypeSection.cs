using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections;

/// <summary>
/// Represents a list of function signatures.
/// </summary>
public sealed class TypeSection : WASMSectionEnumerable<FuncType>
{
    private readonly SortedDictionary<int, IList<FuncType>> _functionTypesByParameterCount;

    public TypeSection()
        : base(WASMSectionId.TypeSection)
    {
        _functionTypesByParameterCount = new SortedDictionary<int, IList<FuncType>>();
    }
    public TypeSection(ref WASMReader input)
        : this()
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            input.ReadByte(); // FUNCTION_TYPE = 0x60
            Add(new FuncType(ref input));
        }
    }

    protected override void Cleared()
    {
        _functionTypesByParameterCount.Clear();
    }
    protected override void Added(int index, FuncType subsection)
    {
        if (!_functionTypesByParameterCount.TryGetValue(subsection.ParameterTypes.Count, out IList<FuncType> functionTypes))
        {
            functionTypes = new List<FuncType>(1);
            _functionTypesByParameterCount.Add(subsection.ParameterTypes.Count, functionTypes);
        }
        functionTypes.Add(subsection);
    }
    protected override void Removed(int index, FuncType subsection)
    {
        if (_functionTypesByParameterCount.TryGetValue(subsection.ParameterTypes.Count, out IList<FuncType> functionTypes))
        {
            functionTypes.Remove(subsection);
        }
    }

    public uint AddOrFindVoidType<T>()
        where T : struct
    {
        return AddOrFindVoidType(typeof(T));
    }
    public uint AddOrFindVoidType<T1, T2>()
        where T1 : struct
        where T2 : struct
    {
        return AddOrFindVoidType(typeof(T1), typeof(T2));
    }
    public uint AddOrFindVoidType<T1, T2, T3>()
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        return AddOrFindVoidType(typeof(T1), typeof(T2), typeof(T3));
    }
    public uint AddOrFindVoidType<T1, T2, T3, T4>()
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        return AddOrFindVoidType(typeof(T1), typeof(T2), typeof(T3), typeof(T4));
    }
    public uint AddOrFindVoidType<T1, T2, T3, T4, T5>()
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        return AddOrFindVoidType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
    }
    public uint AddOrFindVoidType(params Type[] types)
    {
        if (_functionTypesByParameterCount.TryGetValue(types.Length, out IList<FuncType> functionTypes))
        {
            foreach (FuncType functionType in functionTypes)
            {
                if (functionType.ResultTypes.Count > 0) continue;
                for (int i = 0; i < types.Length; i++)
                {
                    if (functionType.ParameterTypes[i] != types[i]) break;
                    if (i + 1 == types.Length) return (uint)IndexOf(functionType);
                }
            }
        }
        return (uint)Add(new FuncType(types, Array.Empty<Type>()));
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (FuncType functionType in this)
        {
            size += sizeof(byte);
            size += functionType.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        const byte FUNCTION_TYPE = 0x60;

        output.WriteULEB128((uint)Count);
        foreach (FuncType functionType in this)
        {
            output.Write(FUNCTION_TYPE);
            functionType.WriteTo(ref output);
        }
    }
}