using System;


namespace Marcetux.Shell
{
    class ExitCommand : ICommand 
    {
        public string Name => "exit";

        public string[] Aliases => new string[0];

        public string Description => "Exit this session.";
        public string Help => "Exit this session.";

        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return "Exiting.";
        }
    }
}
