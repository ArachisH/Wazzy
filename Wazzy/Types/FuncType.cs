using System;
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
                string signature = (ResultType?.Name ?? "void") + " Function(";
                for (int i = 0; i < ParameterTypes.Count; i++)
                {
                    signature += $"{ParameterTypes[i].Name} local_{i}, ";
                }
                return signature.Substring(0, signature.Length - ((ParameterTypes.Count > 0 ? 1 : 0) * 2)) + ")";
            }
        }

        public Type ResultType { get; }
        public List<Type> ParameterTypes { get; }

        public FuncType(WASMModule module)
        {
            ParameterTypes = new List<Type>(module.Input.Read7BitEncodedInt());
            for (int i = 0; i < ParameterTypes.Capacity; i++)
            {
                Type paramType = module.Input.ReadValueType();
                ParameterTypes.Add(paramType);
            }

            bool hasResultType = module.Input.ReadBoolean();
            if (hasResultType)
            {
                ResultType = module.Input.ReadValueType();
            }
        }

        public override void WriteTo(WASMWriter output)
        {
            output.Write7BitEncodedInt(ParameterTypes.Count);
            foreach (Type parameterType in ParameterTypes)
            {
                output.Write(parameterType);
            }

            bool hasResultType = ResultType != null;
            output.Write(hasResultType);
            if (hasResultType)
            {
                output.Write(ResultType);
            }
        }
    }
}