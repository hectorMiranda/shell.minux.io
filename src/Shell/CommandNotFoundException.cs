using System;


namespace Marcetux.Shell
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
