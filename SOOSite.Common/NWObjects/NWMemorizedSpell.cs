namespace SOOSite.Common.NWObjects
{
    public class NWMemorizedSpell : INWSpell
    {
        public int Ready { get; set; }
        public ushort Spell { get; set; }
        public byte SpellMetaMagic { get; set; } //TODO: confirm this is correct value, docs call for short
        public byte SpellFlags { get; set; }
    }
}
