using Wazzy.IO;

namespace Wazzy.Sections
{
    public class StartSection : WASMSection
    {
        public int FunctionId { get; set; }

        public StartSection(ref WASMReader input)
            : base(WASMSectionId.StartSection)
        {
            FunctionId = input.ReadIntLEB128();
        }

        protected override int GetBodySize()
        {
            return WASMReader.GetLEB128Size(FunctionId);
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            output.WriteLEB128(FunctionId);
        }
    }
}