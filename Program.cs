using System;
using Marcetux.Algorithms;
using Marcetux.Shell;
using static System.Console;
using System.Linq;

namespace Marcetux 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine(Processor.Execute("about", null));

            while (true)
            {
                Console.Write("#");
                var input = ReadLine().Split(' ').ToList<string>();
                try
                {
                    WriteLine("{0}", Processor.Execute(input[0], input.Count > 1 ? input.Skip(1).ToArray() : null));
                }
                catch (CommandNotFoundException)
                {
                    WriteLine("Invalid command, please use one of the following commands");
                }
            }
        }
     }
}

