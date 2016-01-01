using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWSound
    {
        public string Comment { get; set; }

        public static NWSound FromGff(GffStruct source)
        {
            NWSound sound = new NWSound();

            return sound;
        }
    }
}
