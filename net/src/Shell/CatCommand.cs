using System;
using Marcetux.Utilities;


namespace Marcetux.Shell
{
    internal class CatCommand : ICommand
    {
        public string Name => "cat";

        public string[] Aliases => new string[]{"more"};

        public string Description => "Concatenate and print files";
        public string Help => "Concatenate and print files";




        public string Execute(string[] args)
        {
            var message = string.Empty;
            
            if(args.Length>0)
            {
                try{
                    var lines = Utils.ReadFrom(args[0]);
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line); 
                    }
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                }
            }else
            {
                message = "filename is required";
            }

            return message;
            
        }
    }
}
