using System;

namespace Marcetux 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var run = true;
            do
            {
                Console.Write("marcetux >");
                var command = Console.ReadLine();
                run = !string.IsNullOrEmpty(command);
                Console.WriteLine(run ? string.Format("{0} not found!", command):"Exiting...");
            }
            while(run);
        }

    }
}
