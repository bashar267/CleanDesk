using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesk.Services
{
    public static class BrowserCleaner
    {
        public static long CleanBrowserCache()
        {
            var browserPaths = new[]
            {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\\Chrome\\User Data\\Default\\Cache"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Edge\\User Data\\Default\\Cache"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles")
        };

            long total = 0;
            foreach (var path in browserPaths)
            {
                if (Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            total += new FileInfo(file).Length;
                            File.Delete(file);
                        }
                        catch { }
                    }
                }
            }
            return total;
        }
    }
}
