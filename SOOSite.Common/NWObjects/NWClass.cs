using System.Collections.Generic;
namespace SOOSite.Common.NWObjects
{
    //TODO: handle lists
    public class NWClass
    {
        public int Class { get; set; }
        public short ClassLevel { get; set; }
        public List<NWMemorizedSpell> MemorizedList { get; set; }
        public List<NWKnownSpell> KnownList { get; set; }
    }
}
