namespace Wazzy.Types
{
    public class MemoryType : Limits // All memory types are limits, but not all limits are memory types.
    {
        public MemoryType(WASMModule module)
            : base(module)
        { }
    }
}