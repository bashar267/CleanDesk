using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace CleanDesk.Utils
{
    public static class Logger
    {
        private static readonly string LogPath = Path.Combine(AppContext.BaseDirectory, "cleandesk.log");

        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(LogPath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch { }
        }
    }
}

