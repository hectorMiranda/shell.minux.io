namespace MinuxShell
{
    public interface ICommand
    {
        string Name { get;  }

        string HelpText { get;  }


        string Execute(string[] args);
    }
}
