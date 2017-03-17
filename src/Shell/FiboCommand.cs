using System;
using System.Text;
using Marcetux.Algorithms;
using System.Linq;


namespace Marcetux.Shell
{
    internal class FiboCommand : ICommand
    {
        public string Name => "fibo";
        public string Description => "Generates a fibonacci sequence for N";
        public string Help => "Generates a fibonacci sequence for N.";




        public string Execute(string[] args)
        {
            var result = new StringBuilder();

            var n = (args.Length >= 1) ? int.Parse(args[0]) : 0; 

            var generator = new FibonacciGenerator();

           foreach(var digit in generator.Generate(n))
                result.Append($" {digit} ");

            return result.ToString();
        }
        
    }
}
