using Wazzy.IO;

namespace Wazzy.Bytecode.Instructions.Control;

public sealed class IfIns : BlockIns
{
    public ElseIns Else
    {
        get => _else;
        set => _else = value;
    }

    public IfIns()
        : base(OPCode.If)
    { }
    public IfIns(ref WASMReader input)
        : base(ref input, OPCode.If)
    { }
}