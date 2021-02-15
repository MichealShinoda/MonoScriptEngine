using System;
using Mono.ScriptingEngine;

namespace MonoCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Script Result :");
            Console.WriteLine("================================================");
            ScriptEngine.Initialize();
            ScriptEngine.ExecuteScript(System.IO.File.ReadAllText("Script.cs"));
            Console.WriteLine("================================================");
            Console.WriteLine("Press a Key to Recompile...");
            Console.ReadKey();
            Main(args);
        }
    }
}
