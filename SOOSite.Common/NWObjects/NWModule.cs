using System.Collections.Generic;

namespace SOOSite.Common.NWObjects
{
    public class NWModule
    {
        public List<NWLocalizedString> LocalizedModuleDescriptions { get; set; }
        public List<NWArea> Areas { get; set; }
        public List<NWItem> Items { get; set; }

    }
}
