using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWEncounter
    {
        public string Comment { get; set; }

        public static NWEncounter FromGff(GffStruct source)
        {
            NWEncounter encounter = new NWEncounter();

            return encounter;
        }
    }
}
