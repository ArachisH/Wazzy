using System.IO;

using Wazzy.IO;

namespace Wazzy.Sections
{
    public abstract class WASMSection : WASMObject
    {
        protected readonly WASMModule _module;

        public int Size { get; }
        public int Start { get; }

        public WASMSectionId Id { get; }

        public WASMSection(WASMModule module, WASMSectionId id)
        {
            _module = module;

            Id = id;
            Size = module.Input.Read7BitEncodedInt();
            Start = module.Input.Position;
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write((byte)Id);

            byte[] bodyData;
            using (var bodyMemory = new MemoryStream())
            using (var bodyWriter = new WASMWriter(bodyMemory))
            {
                WriteBodyTo(bodyWriter, output.Position);

                bodyWriter.Flush();
                bodyMemory.Flush();
                bodyData = bodyMemory.ToArray();
            }

            output.Write7BitEncodedInt(bodyData.Length);
            output.Write(bodyData);
        }
        protected abstract void WriteBodyTo(WASMWriter output, int globalPosition);
    }
}