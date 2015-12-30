
using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public interface INWObject<out T>
    {
        T FromGff(Gff source);
        Gff ToGff();
    }
}
