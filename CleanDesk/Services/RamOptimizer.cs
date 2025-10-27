using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesk.Services
{
    public static class RamOptimizer
    {
        [DllImport("psapi.dll")]
        static extern bool EmptyWorkingSet(IntPtr hProcess);

        public static int FreeMemory()
        {
            int processesOptimized = 0;
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    EmptyWorkingSet(process.Handle);
                    processesOptimized++;
                }
                catch { }
            }
            return processesOptimized;
        }
    }
}
