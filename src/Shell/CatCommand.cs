using System;
using Marcetux.Utilities;


namespace Marcetux.Shell
{
    internal class CatCommand : ICommand
    {
        public string Name => "cat";

        public string[] Aliases => new string[]{"more"};

        public string Description => "Concatenate and print files";
        public string Help => "Concatenate and print files";




        public string Execute(string[] args)
        {
            Console.Clear();
            

            var lines = Utils.ReadFrom("README.md");
            foreach (var line in lines)
            {
                Console.WriteLine(line); 
            }

            return "";
        }
    }
}
