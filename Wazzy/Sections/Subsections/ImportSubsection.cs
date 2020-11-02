using System.Diagnostics;

using Wazzy.Types;

namespace Wazzy.Sections.Subsections
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ImportSubsection
    {
        public string Name { get; }
        public object Value { get; }
        public string Module { get; }
        public ImportDesc Description { get; }

        internal string DebuggerDisplay => $"{Description} Import {Module}.{Name}";

        public ImportSubsection(WASMModule module)
        {
            Module = module.Input.Read7BitEncodedString();
            Name = module.Input.Read7BitEncodedString();
            Value = (Description = (ImportDesc)module.Input.ReadByte()) switch
            {
                ImportDesc.Function => module.Input.Read7BitEncodedInt(),
                ImportDesc.Table => new TableType(module),
                ImportDesc.Memory => new MemoryType(module),
                ImportDesc.Global => new GlobalType(module),
                _ => null
            };
        }
    }
}