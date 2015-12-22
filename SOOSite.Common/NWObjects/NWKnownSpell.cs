namespace SOOSite.Common.NWObjects
{
    public class NWKnownSpell : INWSpell
    {
        public ushort Spell { get; set; }
        public byte SpellFlags { get; set; }
        public byte SpellMetaMagic { get; set; }
    }
}
