using System;
using System.Text;

using Wazzy.IO;

namespace Wazzy.Sections
{
    public class ExportSection : WASMSection
    {
        public string[] Names { get; }
        public byte[] Tags { get; }
        public int[] Indices { get; }

        public ExportSection(ref WASMReader input)
            : base(WASMSectionId.ExportSection)
        {
            int exportCount = input.ReadIntLEB128();
            Names = new string[exportCount];
            Tags = new byte[exportCount];
            Indices = new int[exportCount];

            for (int i = 0; i < exportCount; i++)
            {
                Names[i] = input.ReadString();
                Tags[i] = input.ReadByte();
                Indices[i] = input.ReadIntLEB128();
            }
        }

        protected override int GetBodySize()
        {
            int exportCount = Math.Min(Names.Length, Math.Min(Tags.Length, Indices.Length));

            int size = 0;
            size += WASMReader.GetLEB128Size(exportCount);
            for (int i = 0; i < exportCount; i++)
            {
                size += WASMReader.GetULEB128Size((uint)Names[i].Length);
                size += Encoding.UTF8.GetByteCount(Names[i]);
                size += sizeof(byte);
                size += WASMReader.GetLEB128Size(Indices[i]);
            }
            return size;
        }

        protected override void WriteBodyTo(ref WASMWriter output)
        {
            int exportCount = Math.Min(Names.Length, Math.Min(Tags.Length, Indices.Length));
            output.WriteLEB128(exportCount);
            for (int i = 0; i < exportCount; i++)
            {
                output.WriteString(Names[i]);
                output.Write(Tags[i]);
                output.WriteLEB128(Indices[i]);
            }
        }
    }
}