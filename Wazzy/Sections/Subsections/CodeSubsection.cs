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

        public CodeSubsection(ref WASMReader input)
        {
            uint funcSize = input.ReadIntULEB128();
        DataStart: // Are you judging me right now? 
            int startOfSubsection = input.Position;
            int start = input.Position;
            Locals = new List<Local>(input.ReadIntLEB128());
            for (int i = 0; i < Locals.Capacity; i++)
            {
                Locals.Add(new Local(ref input));
            }

            int startOfBytecode = input.Position;
            int sizeOfBytecode = (int)funcSize - (startOfBytecode - startOfSubsection);

#if Peanut_Debugging
            Expression = input.ReadExpression();
#else
            Body = input.ReadBytes(sizeOfBytecode).ToArray();
#endif
#if Peanut_Debugging
            int bytesRead = input.Position - startOfBytecode;
            if (bytesRead != sizeOfBytecode)
            {
                System.Diagnostics.Debugger.Break();
                input.Position = startOfSubsection;
                goto DataStart; // Abort Abort
            }
#endif
        }

        public override void WriteTo(ref WASMWriter output)
        {
            int funcSize = 0;
            funcSize += WASMReader.GetLEB128Size(Locals.Count);
            foreach (Local local in Locals)
            {
                funcSize += local.GetSize();
            }
            funcSize += Body.Length;

            output.WriteULEB128((uint)funcSize);
            output.WriteLEB128(Locals.Count);
            foreach (Local local in Locals)
            {
                local.WriteTo(ref output);
            }
            output.Write(Body);
        }

        public override int GetSize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(Locals.Count);
            foreach (Local local in Locals)
            {
                size += local.GetSize();
            }
            size += Body.Length;

            // Finally calculate the real size
            size += WASMReader.GetULEB128Size((uint)size);
            return size;
        }
    }
}