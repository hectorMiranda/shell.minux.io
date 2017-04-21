using System;


namespace Marcetux.Shell
{
    internal class TopCommand : ICommand
    {
        public string Name => "top";

        public string[] Aliases => new string[0];

        public string Description => "Display and update sorted information about processes";
        public string Help => @"top(1)                                                                                                                                                                                                                                                top(1)



NAME
       top - display and update sorted information about processes";




        public string Execute(string[] args)
        {
            Console.Clear();
            return null;
        }
    }
}
