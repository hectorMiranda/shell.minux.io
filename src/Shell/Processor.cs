using System.Collections.Generic;

namespace Marcetux.Shell
{
    public static class Processor
    {
        private static readonly Dictionary<string, ICommand> register;
        public static Dictionary<string, ICommand> Register => register;



        static Processor()
        {
            register = new Dictionary<string, ICommand>();
           
 //TODO: fix this          
/*           
            var commands = Assembly.GetExecutingAssembly().GetTypes()
    .Where(x => x.GetInterfaces().Contains(typeof(ICommand))
                && x.GetConstructor(Type.EmptyTypes) != null)
    .Select(x => Activator.CreateInstance(x) as ICommand);



            foreach (ICommand command in commands)
            {
                register.Add(command.Name, command);
            }

*/

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
