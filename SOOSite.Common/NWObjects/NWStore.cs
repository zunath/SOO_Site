using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWStore
    {
        public string Comment { get; set; }

        public static NWStore FromGff(GffStruct source)
        {
            NWStore store = new NWStore();

            return store;
        }
    }
}
