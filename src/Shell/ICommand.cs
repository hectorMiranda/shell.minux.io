namespace Marcetux.Shell
{
    public interface ICommand
    {
        string Name { get;  }

        string Description { get;  }

        string Help { get; }


        string Execute(string[] args);
    }
}
