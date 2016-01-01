using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWCreature
    {
        public string Comment { get; set; }

        public static NWCreature FromGff(GffStruct source)
        {
            NWCreature creature = new NWCreature();


            return creature;
        }

    }
}
