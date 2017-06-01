using System;
using System.IO;
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
                Console.Write(">");
                try
                {
                    var input = ReadLine().Split(' ').ToList<string>();

                    WriteLine("{0}", Processor.Execute(input[0], input.Count > 1 ? input.Skip(1).ToArray() : new string[0]));
                }
                catch (CommandNotFoundException)
                {
                    WriteLine("Invalid command, please use one of the following commands");
                }
                catch (IOException)
                {
                    WriteLine("X(");
                    break;
                }
            }
        }
     }
}

