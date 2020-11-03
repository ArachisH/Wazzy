using System.Collections.Generic;

using Wazzy.IO;
using Wazzy.Types;

namespace Wazzy.Sections.Subsections
{
    public class CodeSubsection : WASMObject
    {
        public byte[] Body { get; set; }
        public List<Local> Locals { get; }

        public CodeSubsection(WASMModule module)
        {
            int size = module.Input.Read7BitEncodedInt();
            int start = module.Input.Position;
            Locals = new List<Local>(module.Input.Read7BitEncodedInt());
            for (int i = 0; i < Locals.Capacity; i++)
            {
                Locals.Add(new Local(module));
            }
            Body = module.Input.ReadBytes(size - (module.Input.Position - start));
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