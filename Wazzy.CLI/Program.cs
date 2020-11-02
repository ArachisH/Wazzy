using System;
using System.IO;

namespace Wazzy.CLI
{
    public class Program
    {
        public static void Main(string[] args) => new Program().Run(args);

        private void Run(string[] args)
        {
            byte[] moduleData = File.ReadAllBytes(args[0]);
            var module = new WASMModule(moduleData);
            module.Disassemble();
            Console.ReadLine();
        }
    }
}