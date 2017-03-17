using System;
using System.Linq;


namespace Marcetux.Shell
{
    internal class AboutCommand : ICommand
    {
        public string Name => "about";
        public string Description => "Show this screen";
        public string Help => @"Yay! you now know how to use the help command, for more interesting stuff get the help for the stressCache command :)";



        public string Execute(string[] args)
        {
            var availableCommands = string.Join(Environment.NewLine, Processor.Register.Select(x =>
                $"{x.Key,-15} - {x.Value.Description,-10}"));


            return $@"

 _ __ ___ (_)_ __  _   ___  __ (_) ___
| '_ ` _ \| | '_ \| | | \ \/ / | |/ _ \
| | | | | | | | | | |_| |>  < _| | (_) |
|_| |_| |_|_|_| |_|\__,_/_/\_(_)_|\___/
The multiplatform minux.io client 

Available commands:

{availableCommands}

            ";
        }
    }
}