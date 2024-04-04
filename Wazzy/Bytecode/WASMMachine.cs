namespace Wazzy.Bytecode;

public sealed class WASMMachine
{
    private readonly WASMModule _context;

    public Stack<object> Stack { get; }

    public WASMMachine(WASMModule context)
    {
        _context = context;

        Stack = new Stack<object>();
    }

    public void Execute(IEnumerable<WASMInstruction> expression, params object[] parameters)
    {
        Execute(expression, _context, Stack, parameters);
    }

    public static Stack<object> Execute(IEnumerable<WASMInstruction> expression, WASMModule context)
    {
        var stack = new Stack<object>();
        Execute(expression, context, stack);
        return stack;
    }
    public static void Execute(IEnumerable<WASMInstruction> expression, WASMModule context, Stack<object> stack, params object[] parameters)
    {
        foreach (WASMInstruction instruction in expression)
        {
            if (instruction.OP == OPCode.End) break;
            instruction.Execute(stack, context, parameters);
        }
    }
}