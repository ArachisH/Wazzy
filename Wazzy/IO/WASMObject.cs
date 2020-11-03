using System.IO;
using System.Collections.Generic;

namespace Wazzy.IO
{
    public abstract class WASMObject
    {
        public abstract void WriteTo(WASMWriter output);

        public static byte[] ToBytes<T>(IList<T> wasmObjs) where T : WASMObject
        {
            if (wasmObjs.Count == 0) return new byte[0];

            using var output = new MemoryStream();
            using var wasmOutput = new WASMWriter(output);
            foreach (WASMObject wasmObj in wasmObjs)
            {
                wasmObj.WriteTo(wasmOutput);
            }
            wasmOutput.Flush();
            return output.ToArray();
        }
        public static byte[] ToBytes(WASMObject wasmObj) => ToBytes(new[] { wasmObj }); // Whatever, don't @ me
    }
}