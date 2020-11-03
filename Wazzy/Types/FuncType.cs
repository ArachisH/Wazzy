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

        public FuncType(WASMModule module)
        {
            ParameterTypes = new List<Type>(module.Input.Read7BitEncodedInt());
            for (int i = 0; i < ParameterTypes.Capacity; i++)
            {
                Type paramType = module.Input.ReadValueType();
                ParameterTypes.Add(paramType);
            }

            ResultTypes = new List<Type>(module.Input.Read7BitEncodedInt());
            for (int i = 0; i < ResultTypes.Capacity; i++)
            {
                Type resultType = module.Input.ReadValueType();
                ResultTypes.Add(resultType);
            }
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(ParameterTypes.Count);
            foreach (Type parameterType in ParameterTypes)
            {
                output.Write(parameterType);
            }

            output.Write7BitEncodedInt(ResultTypes.Count);
            foreach (Type resultType in ResultTypes)
            {
                output.Write(resultType);
            }
        }
    }
}