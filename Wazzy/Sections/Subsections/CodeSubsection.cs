using System.Collections.Generic;

using Wazzy.Types;

namespace Wazzy.Sections.Subsections
{
    public class CodeSubsection
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
    }
}