using System.Diagnostics;
using System.IO.Pipelines;

namespace Wazzy.CLI;

public class Program
{
    public static async Task Main(string[] args)
    {
        byte[] originalModuleData = File.ReadAllBytes(args[0]);
        var originalModule = new WASMModule(originalModuleData);

        var disassembleTime = Stopwatch.StartNew();
        originalModule.Disassemble();
        disassembleTime.Stop();

        string assembledPath = args[0].Replace("original_", string.Empty);
        using var fs = File.Create(assembledPath);
        var writer = PipeWriter.Create(fs);

        var assembleTime = Stopwatch.StartNew();
        originalModule.Assemble(writer);
        await writer.FlushAsync();
        assembleTime.Stop();
        await fs.DisposeAsync();

        Console.WriteLine($"Assemble: " + assembleTime.Elapsed.ToString("mm\\:ss\\.ff"));
        Console.WriteLine($"Disassemble: " + disassembleTime.Elapsed.ToString("mm\\:ss\\.ff"));

        bool areModulesEqual = true;
        byte[] assembledModuleData = await File.ReadAllBytesAsync(assembledPath);
        for (int i = 4; i < Math.Min(originalModuleData.Length, assembledModuleData.Length); i++)
        {
            if (originalModuleData[i] == assembledModuleData[i]) continue;
            string originalChunkHex = BitConverter.ToString(originalModuleData, i, 10);
            string modifiedChunkHex = BitConverter.ToString(assembledModuleData, i, 10);
            areModulesEqual = false;
            Debugger.Break();
        }
        Console.WriteLine("Are Modules Equal: " + areModulesEqual);
        Console.ReadLine();
    }
}