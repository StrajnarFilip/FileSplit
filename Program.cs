/*
Copyright 2021 Filip Strajnar

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

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
