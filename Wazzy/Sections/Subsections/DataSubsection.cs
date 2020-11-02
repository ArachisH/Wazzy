using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class DataSubsection
    {
        public int Offset { get; }
        public int MemoryIndex { get; }
        public byte[] Package { get; set; }
        public WASMInstruction[] ExpressionInstructions { get; set; }

        public DataSubsection(WASMModule module)
        {
            MemoryIndex = module.Input.Read7BitEncodedInt();

            ExpressionInstructions = module.Input.ReadExpression().ToArray();
            Offset = (int)WASMMachine.Execute(ExpressionInstructions).Pop();

            Package = module.Input.ReadBytes(module.Input.Read7BitEncodedInt());
        }
    }
}