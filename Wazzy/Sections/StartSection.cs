using Wazzy.IO;

namespace Wazzy.Sections
{
    public class StartSection : WASMSection
    {
        public int FunctionId { get; set; }

        public StartSection(WASMModule module)
            : base(module, WASMSectionId.StartSection)
        {
            FunctionId = module.Input.Read7BitEncodedInt();
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            output.Write7BitEncodedInt(FunctionId);
        }
    }
}