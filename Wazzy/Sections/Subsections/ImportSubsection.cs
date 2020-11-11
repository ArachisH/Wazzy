using System;
using System.Text;
using System.Diagnostics;

using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections.Subsections
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ImportSubsection : WASMObject
    {
        public string Name { get; }
        public object Value { get; }
        public string Module { get; }
        public ImportDesc Description { get; }

        internal string DebuggerDisplay => $"{Description} Import {Module}.{Name}";

        public ImportSubsection(ref WASMReader input)
        {
            Module = input.ReadString();
            Name = input.ReadString();
            Value = (Description = (ImportDesc)input.ReadByte()) switch
            {
                ImportDesc.Function => input.ReadIntLEB128(),
                ImportDesc.Table => new TableType(ref input),
                ImportDesc.Memory => new MemoryType(ref input),
                ImportDesc.Global => new GlobalType(ref input),
                _ => throw new Exception("Failed to identify import type.")
            };
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.WriteString(Module);
            output.WriteString(Name);
            output.Write((byte)Description);
            if (Description == ImportDesc.Function)
            {
                output.WriteLEB128((int)Value);
            }
            else ((WASMObject)Value).WriteTo(ref output);
        }

        public override int GetSize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Module.Length);
            size += Encoding.UTF8.GetByteCount(Module);
            size += WASMReader.GetLEB128Size(Name.Length);
            size += Encoding.UTF8.GetByteCount(Name);
            size += sizeof(byte);
            size += Description == ImportDesc.Function ?
                WASMReader.GetLEB128Size((int)Value) : ((WASMObject)Value).GetSize();
            return size;
        }
    }
}