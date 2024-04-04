using Wazzy.IO;
using Wazzy.Sections.Subsections;

namespace Wazzy.Sections;

public sealed class ImportSection : WASMSectionEnumerable<ImportSubsection>, IFunctionOffsetProvider
{
    private readonly int _originalLinearFunctionOffset;
    private readonly Dictionary<ImpexDesc, IReadOnlyList<ImportSubsection>> _imports;
    private readonly List<ImportSubsection> _functions, _tables, _memories, _globals;

    public int FunctionOffset => _functions.Count - _originalLinearFunctionOffset;

    public ImportSection()
        : base(WASMSectionId.ImportSection)
    {
        _tables = new List<ImportSubsection>();
        _globals = new List<ImportSubsection>();
        _memories = new List<ImportSubsection>();
        _functions = new List<ImportSubsection>();
        _imports = new Dictionary<ImpexDesc, IReadOnlyList<ImportSubsection>>
        {
            [ImpexDesc.Function] = _functions.AsReadOnly(),
            [ImpexDesc.Table] = _tables.AsReadOnly(),
            [ImpexDesc.Memory] = _memories.AsReadOnly(),
            [ImpexDesc.Global] = _globals.AsReadOnly()
        };
    }
    public ImportSection(ref WASMReader input)
        : this()
    {
        Capacity = (int)input.ReadIntULEB128();
        for (int i = 0; i < Capacity; i++)
        {
            Add(new ImportSubsection(ref input));
        }
        _originalLinearFunctionOffset = _functions.Count;
    }

    public uint Add(string module, string name, uint functionTypeIndex)
    {
        int functionImportIndex = FunctionOffset;
        Insert(IndexOf(_functions[0]) + functionImportIndex, new ImportSubsection(module, name, functionTypeIndex));

        return (uint)functionImportIndex;
    }
    public IReadOnlyList<ImportSubsection> Choose(ImpexDesc description) => _imports[description];

    protected override void Cleared()
    {
        _tables.Clear();
        _globals.Clear();
        _memories.Clear();
        _functions.Clear();
    }
    protected override void Added(int index, ImportSubsection subsection)
    {
        (subsection.Description switch
        {
            ImpexDesc.Table => _tables,
            ImpexDesc.Global => _globals,
            ImpexDesc.Memory => _memories,
            ImpexDesc.Function => _functions,
            _ => throw new ArgumentException(null, nameof(subsection))
        }).Add(subsection);
    }
    protected override void Removed(int index, ImportSubsection subsection)
    {
        (subsection.Description switch
        {
            ImpexDesc.Table => _tables,
            ImpexDesc.Global => _globals,
            ImpexDesc.Memory => _memories,
            ImpexDesc.Function => _functions,
            _ => throw new ArgumentException(null, nameof(subsection))
        }).Remove(subsection);
    }

    protected override int GetBodySize()
    {
        int size = 0;
        size += WASMReader.GetULEB128Size((uint)Count);
        foreach (ImportSubsection import in this)
        {
            size += import.GetSize();
        }
        return size;
    }
    protected override void WriteBodyTo(ref WASMWriter output)
    {
        output.WriteULEB128((uint)Count);
        foreach (ImportSubsection import in this)
        {
            import.WriteTo(ref output);
        }
    }
}