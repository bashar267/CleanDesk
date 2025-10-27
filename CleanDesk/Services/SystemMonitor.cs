using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesk.Services
{
    public class SystemMonitor
    {
        private readonly PerformanceCounter _cpu = new("Processor", "% Processor Time", "_Total");
        private readonly PerformanceCounter _ram = new("Memory", "Available MBytes");

        public (float cpu, float ramFree) GetStats()
        {
            return (_cpu.NextValue(), _ram.NextValue());
        }
    }
}