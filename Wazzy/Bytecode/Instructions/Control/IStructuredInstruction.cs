using System.Collections;

namespace Wazzy.Bytecode.Instructions.Control;

public interface IStructuredInstruction : IEnumerable<WASMInstruction>
{
    public List<WASMInstruction> Expression { get; }

    protected ElseIns GetElseInstruction() => null;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    IEnumerator<WASMInstruction> IEnumerable<WASMInstruction>.GetEnumerator()
    {
        ElseIns elseInstruction = GetElseInstruction();
        IEnumerable<WASMInstruction> elseExpressionWithElse = null;
        if (elseInstruction != null)
        {
            elseExpressionWithElse = elseInstruction.Prepend(elseInstruction);
        }
        foreach (WASMInstruction outerInstruction in Enumerable.Concat(Expression, elseExpressionWithElse ?? Enumerable.Empty<WASMInstruction>()))
        {
            yield return outerInstruction;
            if (outerInstruction != elseInstruction && outerInstruction is IStructuredInstruction structuredInstruction)
            {
                foreach (WASMInstruction innerInstruction in structuredInstruction)
                {
                    yield return innerInstruction;
                }
            }
        }
    }
}