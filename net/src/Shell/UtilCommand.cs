using System;
using System.Text;
using Marcetux.Algorithms;
using System.Linq;


namespace Marcetux.Shell
{
    internal class UtilCommand : ICommand
    {
        public string Name => "util";
        public string Description => "Lets ";

        public string[] Aliases => new string[0];

        public string Help => "This algorithms can help to you to prepare for your next interview";

///Expects following syntax: algo fibo params[]s
        public string Execute(string[] args)
        {
            var result = String.Empty;
            var utilToRun = args.Length > 0? args[0]: String.Empty;

            switch(utilToRun){
                case "fibo":
                    result = RunFibo();
                    break;
                case "twoSum":
                    result = RunTwoSum();
                    break;
                default:
                    result = "util not found!";
                    break; 
            }

            return result;
        }


        public string RunTwoSum()
        {

            return null;
        }

        public string RunFibo()
        {
            var result = new StringBuilder();

            var generator = new FibonacciGenerator();

           foreach(var digit in generator.Generate(15))
                result.Append($" {digit} ");
            
            return result.ToString();

        }
        
    }
}
