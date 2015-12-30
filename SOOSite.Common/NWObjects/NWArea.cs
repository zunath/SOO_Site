using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWArea: INWObject<NWArea>
    {
        public int ChanceOfLightning { get; set; }
        public int ChanceOfRain { get; set; }
        public int ChanceOfSnow { get; set; }
        public string Comments { get; set; }
        public int CreatorID { get; set; }
        public bool HasDayNightCycle { get; set; }

        public NWArea FromGff(Gff source)
        {
            throw new System.NotImplementedException();
        }

        public Gff ToGff()
        {
            throw new System.NotImplementedException();
        }
    }
}
