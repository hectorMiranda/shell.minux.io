using System;
using System.Diagnostics;


namespace Marcetux.Shell
{
    internal class TopCommand : ICommand
    {
        public string Name => "top";

        public string[] Aliases => new string[0];

        public string Description => "Display and update sorted information about processes";
        public string Help => @"";

        public string Execute(string[] args)
        {
            Process[] processlist = Process.GetProcesses();

            foreach(Process p in processlist)
            {
                try 
                {
                    Console.WriteLine("Process: {0} ID: {1} STARTTIME: {2} CPUTIME: {3} #THREADS: {4}", p.ProcessName, p.Id, p.StartTime, p.TotalProcessorTime, p.Threads.Count);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERROR:{ex.Message} Hint: try sudo!");
                }
            }
        
            return null;
        }
    }
}
