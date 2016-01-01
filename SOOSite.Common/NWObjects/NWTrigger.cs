using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWTrigger
    {
        public string Comment { get; set; }

        public static NWTrigger FromGff(GffStruct source)
        {
            NWTrigger trigger = new NWTrigger();

            return trigger;
        }
    }
}
