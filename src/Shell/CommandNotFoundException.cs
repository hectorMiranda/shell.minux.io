using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinuxShell
{
    class CommandNotFoundException : Exception
    {
        public string RequestedCommandName { get; private set; }

        public CommandNotFoundException() : base() { }

        public CommandNotFoundException(string commandName)
            : base(commandName)
        {
            RequestedCommandName = commandName;
        }

        public CommandNotFoundException(string commandName, Exception inner)
            : base(commandName, inner)
        {
            RequestedCommandName = commandName;
        }

    }
}
