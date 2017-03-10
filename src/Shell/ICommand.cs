using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeDeskConsole
{
    public interface ICommand
    {
        string Name { get;  }

        string HelpText { get;  }


        string Execute(string[] args);
    }
}
