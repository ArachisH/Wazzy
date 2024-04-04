using Wazzy.IO;

namespace Wazzy.Types;

public abstract class WASMType : WASMObject
{
    public static Type GetValueType(byte valueTypeId) => valueTypeId switch
    {
        0x7F => typeof(int),
        0x7E => typeof(long),
        0x7D => typeof(float),
        0x7C => typeof(double),
        _ => throw new ArgumentException($"The provided {nameof(valueTypeId)}({valueTypeId}, 0x{valueTypeId:X2}) is currently not supported in the WebAssembly specificiation.")
    };
    public static byte GetValueTypeId(Type valueType) => Type.GetTypeCode(valueType) switch
    {
        TypeCode.Int32 => 0x7F,
        TypeCode.Int64 => 0x7E,
        TypeCode.Single => 0x7D,
        TypeCode.Double => 0x7C
    };
    public static bool IsSupportedValueTypeId(byte valueTypeId) => (valueTypeId >= 124 && valueTypeId <= 127);
}