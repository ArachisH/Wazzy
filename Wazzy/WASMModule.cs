using System.Buffers;
using System.Collections;

using Wazzy.IO;
using Wazzy.Sections;

namespace Wazzy;

public class WASMModule : IEnumerable<WASMSection>
{
    private const int HEADER_SIZE = 8;
    private const uint MAGIC_HEADER = 0x6D736100;

    private ReadOnlyMemory<byte> _data;
    private readonly SortedDictionary<WASMSectionId, WASMSection> _sections;

    public uint Version { get; }
    public WASMSection this[WASMSectionId id] => _sections[id];

    #region Section Properties
    public List<CustomSection> CustomSections { get; }

    private TypeSection _typeSec;
    public TypeSection TypeSec
    {
        get => _typeSec;
        set => RecordSection(value, out _typeSec);
    }

    private ImportSection _importSec;
    public ImportSection ImportSec
    {
        get => _importSec;
        set => RecordSection(value, out _importSec);
    }

    private FunctionSection _functionSec;
    public FunctionSection FunctionSec
    {
        get => _functionSec;
        set => RecordSection(value, out _functionSec);
    }

    private TableSection _tableSec;
    public TableSection TableSec
    {
        get => _tableSec;
        set => RecordSection(value, out _tableSec);
    }

    private MemorySection _memorySec;
    public MemorySection MemorySec
    {
        get => _memorySec;
        set => RecordSection(value, out _memorySec);
    }

    private GlobalSection _globalSec;
    public GlobalSection GlobalSec
    {
        get => _globalSec;
        set => RecordSection(value, out _globalSec);
    }

    private ExportSection _exportSec;
    public ExportSection ExportSec
    {
        get => _exportSec;
        set => RecordSection(value, out _exportSec);
    }

    private StartSection _startSec;
    public StartSection StartSec
    {
        get => _startSec;
        set => RecordSection(value, out _startSec);
    }

    private ElementSection _elementSec;
    public ElementSection ElementSec
    {
        get => _elementSec;
        set => RecordSection(value, out _elementSec);
    }

    private CodeSection _codeSec;
    public CodeSection CodeSec
    {
        get => _codeSec;
        set => RecordSection(value, out _codeSec);
    }

    private DataSection _dataSec;
    public DataSection DataSec
    {
        get => _dataSec;
        set => RecordSection(value, out _dataSec);
    }
    #endregion

    public WASMModule()
    {
        _sections = new SortedDictionary<WASMSectionId, WASMSection>();

        Version = 1;
        CustomSections = new List<CustomSection>();
    }
    public WASMModule(string path)
        : this(File.ReadAllBytes(path))
    { }
    public WASMModule(ReadOnlyMemory<byte> data)
        : this()
    {
        _data = data;

        var input = new WASMReader(data.Span);
        if (input.ReadUInt32() != MAGIC_HEADER)
        {
            throw new Exception(@"Invalid WASM file, does not begin with ""\0asm"".");
        }
        Version = input.ReadUInt32();
    }

    public bool Contains(WASMSectionId id) => _sections.ContainsKey(id);
    public bool TryGetSection(WASMSectionId id, out WASMSection section) => _sections.TryGetValue(id, out section);

    public void Disassemble()
    {
        var input = new WASMReader(_data.Span.Slice(HEADER_SIZE));
        while (input.IsDataAvailable)
        {
            var id = (WASMSectionId)input.ReadByte();
            int length = (int)input.ReadIntULEB128();
            WASMSection section = ParseSection(id, length, ref input); // This will override any section that was set prior to calling Disassemble().

            if (id == WASMSectionId.CustomSection)
            {
                CustomSections.Add((CustomSection)section);
            }
        }

        _data = null;
        GC.Collect();
    }
    public void Assemble(WASMWriter output)
    {
        output.Write(MAGIC_HEADER);
        output.Write(Version);
        foreach (WASMSection section in _sections.Values.Concat(CustomSections))
        {
            section.WriteTo(ref output);
        }
    }
    public void Assemble(IBufferWriter<byte> output)
    {
        var headerWriter = new WASMWriter(output.GetSpan(HEADER_SIZE));
        headerWriter.Write(MAGIC_HEADER);
        headerWriter.Write(Version);
        output.Advance(HEADER_SIZE);

        foreach (WASMSection section in _sections.Values.Concat(CustomSections))
        {
            section.WriteTo(output);
        }
    }

    private void RecordSection<T>(T section, out T backingField) where T : WASMSection
        => _sections[section.Id] = backingField = section;
    protected virtual WASMSection ParseSection(WASMSectionId id, int length, ref WASMReader input) => id switch
    {
        WASMSectionId.CustomSection => new CustomSection(length, ref input),

        WASMSectionId.TypeSection => TypeSec = new TypeSection(ref input),
        WASMSectionId.ImportSection => ImportSec = new ImportSection(ref input),
        WASMSectionId.FunctionSection => FunctionSec = new FunctionSection(ref input),
        WASMSectionId.TableSection => TableSec = new TableSection(ref input),
        WASMSectionId.MemorySection => MemorySec = new MemorySection(ref input),
        WASMSectionId.GlobalSection => GlobalSec = new GlobalSection(ref input),
        WASMSectionId.ExportSection => ExportSec = new ExportSection(ref input, ImportSec),
        WASMSectionId.StartSection => StartSec = new StartSection(ref input),
        WASMSectionId.ElementSection => ElementSec = new ElementSection(ref input, ImportSec),
        WASMSectionId.CodeSection => CodeSec = new CodeSection(ref input, ImportSec),
        WASMSectionId.DataSection => DataSec = new DataSection(ref input),

        _ => throw new Exception($"Unable to determine section type. {id}(0x{id:X})")
    };

    public byte[] ToArray()
    {
        var arrayWriter = new ArrayBufferWriter<byte>(HEADER_SIZE);
        Assemble(arrayWriter);
        return arrayWriter.WrittenSpan.ToArray();
    }

    #region IEnumerable<T> Implementation
    public IEnumerator<WASMSection> GetEnumerator()
    {
        foreach (WASMSection section in CustomSections.Concat(_sections.Values))
        {
            yield return section;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    #endregion
}