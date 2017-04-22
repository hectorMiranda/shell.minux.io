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
                    result.Append(string.Format("{0, -30}\t directory", d.Name));
                }

                foreach (FileInfo f in dir.GetFiles())
                {
                    result.Append(string.Format("{0, -30}\t File", f.Name));
                }
            }

            return result.ToString();

        }
    }
}
