using SOOSite.Common.GffRawStructures;

namespace SOOSite.Common.NWObjects
{
    public interface INWObject
    {
        INWObject ToMappedObject(Gff data);
        string FileName { get; set; }
    }
}
