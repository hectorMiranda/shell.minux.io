using System;
using Marcetux.Utilities;
using static System.Console;

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

                switch(command){
                    case "fib":
                        FibonacciNumber(15);
                        break;
                    case "exit":
                        run = false;
                        break;
                    default:
                        WriteLine($"{run} not found");
                        break;

                }    
            }while(run);
        }

        public static void FibonacciNumber(int n){
           var generator = new FibonacciGenerator();

           foreach(var digit in generator.Generate(15))
                WriteLine(digit);

        }



        }


}

