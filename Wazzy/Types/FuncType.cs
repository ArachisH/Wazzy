using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using Wazzy.IO;

namespace Wazzy.Types
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class FuncType : WASMType
    {
        internal string DebuggerDisplay
        {
            get
            {
                string results = ResultTypes.Count switch
                {
                    0 => "void",
                    1 => ResultTypes[0].Name,

                    _ => $"({string.Join(", ", ResultTypes.Select(t => t.Name))})"
                };

                string signature = results + " Function(";
                for (int i = 0; i < ParameterTypes.Count; i++)
                {
                    signature += $"{ParameterTypes[i].Name} local_{i}, ";
                }
                return signature.Substring(0, signature.Length - ((ParameterTypes.Count > 0 ? 1 : 0) * 2)) + ")";
            }
        }

        public List<Type> ResultTypes { get; }
        public List<Type> ParameterTypes { get; }

        public FuncType(ref WASMReader input)
        {
            ParameterTypes = new List<Type>(input.ReadIntLEB128());
            for (int i = 0; i < ParameterTypes.Capacity; i++)
            {
                Type paramType = input.ReadValueType();
                ParameterTypes.Add(paramType);
            }

            ResultTypes = new List<Type>(input.ReadIntLEB128());
            for (int i = 0; i < ResultTypes.Capacity; i++)
            {
                Type resultType = input.ReadValueType();
                ResultTypes.Add(resultType);
            }
        }

        public override void WriteTo(ref WASMWriter output)
        {
            output.WriteLEB128(ParameterTypes.Count);
            foreach (Type parameterType in ParameterTypes)
            {
                output.Write(parameterType);
            }

            output.WriteLEB128(ResultTypes.Count);
            foreach (Type resultType in ResultTypes)
            {
                output.Write(resultType);
            }
        }

        public override int GetSize()
        {
            int size = 0;
            size += WASMReader.GetLEB128Size(ParameterTypes.Count);
            size += ParameterTypes.Count * sizeof(byte);

            size += WASMReader.GetLEB128Size(ResultTypes.Count);
            size += ResultTypes.Count * sizeof(byte);
            return size;
        }
    }
}