using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinuxShell
{
    public interface ICommand
    {
        string Name { get;  }

        string HelpText { get;  }


        string Execute(string[] args);
    }
}
