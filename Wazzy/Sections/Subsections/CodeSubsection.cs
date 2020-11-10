//#define Peanut_Debugging

using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Types;
using Wazzy.Bytecode;

namespace Wazzy.Sections.Subsections
{
    public class CodeSubsection : WASMObject
    {
        public byte[] Body { get; set; }
        public List<Local> Locals { get; }
        public List<WASMInstruction> Expression { get; }

        public CodeSubsection(WASMModule module)
        {
            int sizeOfSubsection = module.Input.Read7BitEncodedInt();

        DataStart: // Are you judging me right now? 
            int startOfSubsection = module.Input.Position;
            Locals = new List<Local>(module.Input.Read7BitEncodedInt());
            for (int i = 0; i < Locals.Capacity; i++)
            {
                Locals.Add(new Local(module));
            }

            int startOfBytecode = module.Input.Position;
            int sizeOfBytecode = sizeOfSubsection - (startOfBytecode - startOfSubsection);

#if Peanut_Debugging
            Expression = module.Input.ReadExpression();
#else
            Body = module.Input.ReadBytes(sizeOfBytecode);
#endif
#if Peanut_Debugging
            int bytesRead = module.Input.Position - startOfBytecode;
            if (bytesRead != sizeOfBytecode)
            {
                System.Diagnostics.Debugger.Break();
                module.Input.Position = startOfSubsection;
                goto DataStart; // Abort Abort
            }
#endif
        }

        public override void WriteTo(WASMWriter output)
        {
            int size = WASMReader.Get7BitEncodedIntSize(Locals.Count) + Body.Length;
            byte[] localsData = ToBytes(Locals);
            size += localsData.Length;

            output.Write7BitEncodedInt(size);
            output.Write7BitEncodedInt(Locals.Count);
            output.Write(localsData);
            output.Write(Body);
        }
    }
}