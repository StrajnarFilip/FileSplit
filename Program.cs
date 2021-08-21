using System;
using System.Linq;

namespace FileSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any(a => a == "-c" || a == "--combine"))
            {
                if (args.Length == 1)
                {
                    FileHelp.CombineFile(".");
                    return;
                }
                if (args.Length == 2)
                {
                    FileHelp.CombineFile(new string(args.First(x => x != "-c" && x != "--combine").ToArray()));
                    return;
                }
            }

            if (args.Length == 1)
            {
                FileHelp.SplitFile(args[0], 8_000_000);
                return;
            }
            if (args.Length == 2)
            {
                FileHelp.SplitFile(args[0], uint.Parse(args[1]));
                return;
            }
            System.Console.WriteLine("Usage: filesplit <file path> <split length in bytes>");
        }
    }
}
