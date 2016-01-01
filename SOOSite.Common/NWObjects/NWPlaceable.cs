using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWPlaceable
    {
        public string Comment { get; set; }

        public static NWPlaceable FromGff(GffStruct source)
        {
            NWPlaceable placeable = new NWPlaceable();

            return placeable;
        }
    }
}
