using Wazzy.IO;

namespace Wazzy.Sections;

public sealed class StartSection : WASMSection
{
    public uint FunctionIndex { get; set; }

    public StartSection(ref WASMReader input)
        : base(WASMSectionId.StartSection)
    {
        FunctionIndex = input.ReadIntULEB128();
    }

    protected override int GetBodySize() => WASMReader.GetULEB128Size(FunctionIndex);
    protected override void WriteBodyTo(ref WASMWriter output) => output.WriteULEB128(FunctionIndex);
}