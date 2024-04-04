using System.Diagnostics;

using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections.Subsections;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class ImportSubsection : WASMObject
{
    public string Name { get; set; }
    public object Value { get; set; }
    public string Module { get; set; }
    public ImpexDesc Description { get; set; }

    internal string DebuggerDisplay => $"{Description} Import {Module}.{Name}";

    public ImportSubsection(ref WASMReader input)
    {
        Module = input.ReadString();
        Name = input.ReadString();
        Value = (Description = (ImpexDesc)input.ReadByte()) switch
        {
            ImpexDesc.Function => input.ReadIntULEB128(),
            ImpexDesc.Table => new TableType(ref input),
            ImpexDesc.Memory => new MemoryType(ref input),
            ImpexDesc.Global => new GlobalType(ref input),
            _ => throw new Exception("Failed to identify import type.")
        };
    }

    private ImportSubsection(string module, string name)
    {
        Name = name;
        Module = module;
    }
    public ImportSubsection(string module, string name, TableType table)
        : this(module, name)
    {
        Value = table;
        Description = ImpexDesc.Table;
    }
    public ImportSubsection(string module, string name, MemoryType memory)
        : this(module, name)
    {
        Value = memory;
        Description = ImpexDesc.Memory;
    }
    public ImportSubsection(string module, string name, GlobalType global)
        : this(module, name)
    {
        Value = global;
        Description = ImpexDesc.Global;
    }
    public ImportSubsection(string module, string name, uint functionTypeIndex)
        : this(module, name)
    {
        Value = functionTypeIndex;
        Description = ImpexDesc.Function;
    }

    public override int GetSize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size(Module);
        size += WASMReader.GetULEB128Size(Name);
        size += sizeof(byte);
        size += Description == ImpexDesc.Function ? WASMReader.GetULEB128Size((uint)Value) : ((WASMObject)Value).GetSize();
        return size;
    }
    public override void WriteTo(ref WASMWriter output)
    {
        output.WriteString(Module);
        output.WriteString(Name);
        output.Write((byte)Description);
        if (Description == ImpexDesc.Function)
        {
            output.WriteULEB128((uint)Value);
        }
        else ((WASMObject)Value).WriteTo(ref output);
    }
}