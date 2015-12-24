using SOOSite.Common;
using SOOSite.Common.NWObjects;
using System.IO;

namespace ModReaderTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileInPath = @"C:\Projects\SOO_Site\SOOSite.Data\Module\Solar Odyssey Online v51.mod";
            
            ModuleReader reader = new ModuleReader();
            NWModule module = reader.LoadModule(fileInPath);
        }
    }
}
