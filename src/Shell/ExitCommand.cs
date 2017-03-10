using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
