using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MinuxShell
{
    public static class Shell
    {
        static readonly Dictionary<string, ICommand> register;


        static Shell()
        {
            register = new Dictionary<string, ICommand>();
            var commands = Assembly.GetExecutingAssembly().GetTypes()
    .Where(x => x.GetInterfaces().Contains(typeof(ICommand))
                && x.GetConstructor(Type.EmptyTypes) != null)
    .Select(x => Activator.CreateInstance(x) as ICommand);

            foreach (ICommand command in commands)
            {
                register.Add(command.Name, command);
            }
        }


        public static ICommand GetCommand(string name)
        {
            return register.ContainsKey(name) ? register[name] : null;
        }

        public static string Execute(string name, string[] args)
        {
            if (register.ContainsKey(name))
            {
                return register[name].Execute(args);
            }
            else
            {
                throw new CommandNotFoundException(name);
            }
        }

    }
}
