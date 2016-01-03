using SOOSite.Common.Enums;

namespace SOOSite.Common.NWObjects
{
    public class NWSpecialAbility
    {
        public ushort SpellID { get; set; }
        public byte SpellCasterLevel { get; set; }
        public SpellFlagType SpellFlags { get; set; }
    }
}
