namespace Wazzy.Types
{
    public class TableType : WASMType
    {
        public byte ElementType { get; set; } 
        public Limits Limits { get; set; }

        public TableType(WASMModule module)
        {
            ElementType = module.Input.ReadByte(); // WASM v1 only supports funcref(0x70), but will perhaps support more in the future.
            Limits = new Limits(module);
        }
    }
}