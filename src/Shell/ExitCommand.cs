using System;


namespace MinuxShell
{
    class ExitCommand : ICommand 
    {
        public string Name => "exit";
        public string HelpText => "Exit this session.";

        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return "Exiting.";
        }
    }
}
