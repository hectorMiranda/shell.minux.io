using System;
using System.IO;
using System.Text;


namespace Marcetux.Shell
{
    internal class LsCommand : ICommand
    {
        public string Name => "ls";

        public string[] Aliases => new string[]{"dir"};

        public string Description => "Clears the console screen.";
        public string Help => "Clears the console screen.";




        public string Execute(string[] args)
        {
            StringBuilder result = new StringBuilder();  

            if (args.Length == 0)
            {
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    result.Append($"d {d.LastAccessTime} {d.Name}{Environment.NewLine}");
                }

                foreach (FileInfo f in dir.GetFiles())
                {
                    result.Append($"d {f.LastAccessTime} {f.Name}{Environment.NewLine}");
                }
            }

            return result.ToString();

        }
    }
}
