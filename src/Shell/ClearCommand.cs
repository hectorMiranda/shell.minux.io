using System;


namespace Marcetux.Shell
{
    internal class ClearCommand : ICommand
    {
        public string Name => "clear";
        public string Description => "Clears the console screen.";
        public string Help => "Clears the console screen.";




        public string Execute(string[] args)
        {
            Console.Clear();
            return null;
        }
    }
}
