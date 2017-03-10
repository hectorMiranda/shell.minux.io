using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeDeskConsole
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
