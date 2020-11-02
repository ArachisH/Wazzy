using System.IO;
using System.Text;

namespace Wazzy.IO
{
    public class WASMWriter : BinaryWriter
    {
        public WASMWriter()
            : base(new MemoryStream())
        { }
        public WASMWriter(Stream output)
            : base(output)
        { }
        public WASMWriter(Stream output, Encoding encoding)
            : base(output, encoding)
        { }
        public WASMWriter(Stream output, Encoding encoding, bool leaveOpen)
            : base(output, encoding, leaveOpen)
        { }

        new public void Write7BitEncodedInt(int value)
        {
            base.Write7BitEncodedInt(value);
        }
    }
}