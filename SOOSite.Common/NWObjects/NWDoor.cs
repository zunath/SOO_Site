using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWDoor
    {
        public string Comment { get; set; }

        public static NWDoor FromGff(GffStruct source)
        {
            NWDoor door = new NWDoor();

            return door;
        }
    }
}
