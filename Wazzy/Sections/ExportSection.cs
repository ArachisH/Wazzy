using System;

using Wazzy.IO;

namespace Wazzy.Sections
{
    public class ExportSection : WASMSection
    {
        public string[] Names { get; }
        public byte[] Tags { get; }
        public int[] Indices { get; }

        public ExportSection(WASMModule module)
            : base(module, WASMSectionId.ExportSection)
        {
            int exportCount = module.Input.Read7BitEncodedInt();
            Names = new string[exportCount];
            Tags = new byte[exportCount];
            Indices = new int[exportCount];

            for (int i = 0; i < exportCount; i++)
            {
                Names[i] = module.Input.Read7BitEncodedString();
                Tags[i] = module.Input.ReadByte();
                Indices[i] = module.Input.Read7BitEncodedInt();
            }
        }

        protected override void WriteBodyTo(WASMWriter output, int globalPosition)
        {
            int exportCount = Math.Min(Names.Length, Math.Min(Tags.Length, Indices.Length));
            output.Write7BitEncodedInt(exportCount);
            for (int i = 0; i < exportCount; i++)
            {
                output.Write7BitEncodedString(Names[i]);
                output.Write(Tags[i]);
                output.Write7BitEncodedInt(Indices[i]);
            }
        }
    }
}