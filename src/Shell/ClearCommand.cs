using System;


namespace MinuxShell
{
    internal class ClearCommand : ICommand
    {
        public string Name => "clear";
        public string HelpText => "Clears the console screen.";



        public string Execute(string[] args)
        {
            Console.Clear();
            return null;
        }
    }
}
