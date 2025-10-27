using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesk.Services
{
    public static class FileCleaner
    {
        public static long CleanTempFiles()
        {
            string[] tempPaths = {
            Path.GetTempPath(),
            Environment.GetFolderPath(Environment.SpecialFolder.InternetCache),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp")
        };

            long totalFreed = 0;
            foreach (var path in tempPaths)
            {
                if (!Directory.Exists(path)) continue;

                foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                {
                    try
                    {
                        long size = new FileInfo(file).Length;
                        File.Delete(file);
                        totalFreed += size;
                    }
                    catch { }
                }
            }
            return totalFreed;
        }
    }
}
