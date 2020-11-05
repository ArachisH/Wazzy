using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Sections;

namespace Wazzy
{
    public class WASMModule : IEnumerable<WASMSection>, IDisposable
    {
        private bool _disposed;
        private readonly SortedDictionary<WASMSectionId, WASMSection> _sections;

        protected internal WASMReader Input { get; }

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

        public uint Version { get; }

        public WASMModule()
        {
            _sections = new SortedDictionary<WASMSectionId, WASMSection>();
            CustomSections = new List<CustomSection>();
        }
        public WASMModule(string path)
            : this(File.OpenRead(path))
        { }
        public WASMModule(byte[] data)
            : this(new MemoryStream(data))
        { }
        public WASMModule(Stream input)
            : this(input, false)
        { }
        public WASMModule(Stream input, bool leaveOpen)
            : this(new WASMReader(input, leaveOpen))
        { }
        public WASMModule(WASMReader input)
            : this()
        {
            Input = input;
            if (!Encoding.UTF8.GetString(input.ReadBytes(4))
                .Equals("\0asm", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(@"Invalid WASM file, does not begin with ""\0asm"".");
            }
            Version = Input.ReadUInt32();
        }

        public bool ContainsSection(WASMSectionId id) => _sections.ContainsKey(id);
        public bool TryGetSection(WASMSectionId id, out WASMSection section) => _sections.TryGetValue(id, out section);

        public void Disassemble()
        {
            while (Input.BaseStream.CanRead && Input.BaseStream.Position != Input.BaseStream.Length)
            {
                var id = (WASMSectionId)Input.ReadByte();
                WASMSection section = ParseSection(id); // This will override any section that was set prior to calling Disassemble().
                if (!Enum.IsDefined(typeof(WASMSectionId), id))
                {
                    throw new Exception($"Unable to determine section type. {id}(0x{id:X})");
                }
                else if (id == WASMSectionId.CustomSection)
                {
                    CustomSections.Add((CustomSection)section);
                }
            }
        }
        public void Assemble(WASMWriter output)
        {
            output.Write(new byte[] { 0, (byte)'a', (byte)'s', (byte)'m' });
            output.Write(Version);
            foreach (WASMSection section in _sections.Values.Concat(CustomSections))
            {
                section.WriteTo(output);
            }
            output.Flush();
        }

        public byte[] ToArray()
        {
            using var output = new MemoryStream();
            CopyTo(output);

            return output.ToArray();
        }
        public void CopyTo(Stream output)
        {
            using var wasmOutput = new WASMWriter(output);
            Assemble(wasmOutput);
        }

        protected virtual WASMSection ParseSection(WASMSectionId id) => id switch
        {
            WASMSectionId.CustomSection => new CustomSection(this),
            WASMSectionId.TypeSection => TypeSec = new TypeSection(this),
            WASMSectionId.ImportSection => ImportSec = new ImportSection(this),
            WASMSectionId.FunctionSection => FunctionSec = new FunctionSection(this),
            WASMSectionId.TableSection => TableSec = new TableSection(this),
            WASMSectionId.MemorySection => MemorySec = new MemorySection(this),
            WASMSectionId.GlobalSection => GlobalSec = new GlobalSection(this),
            WASMSectionId.ExportSection => ExportSec = new ExportSection(this),
            WASMSectionId.StartSection => StartSec = new StartSection(this),
            WASMSectionId.ElementSection => ElementSec = new ElementSection(this),
            WASMSectionId.CodeSection => CodeSec = new CodeSection(this),
            WASMSectionId.DataSection => DataSec = new DataSection(this),
            _ => null
        };

        private void RecordSection<T>(T section, out T backingField) where T : WASMSection
            => _sections[section.Id] = backingField = section;

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Input?.Dispose();
            }
            _disposed = true;
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
}