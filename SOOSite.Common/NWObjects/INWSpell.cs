namespace SOOSite.Common.NWObjects
{
    public interface INWSpell
    {
        ushort Spell { get; set; }
        byte SpellFlags { get; set; }
        byte SpellMetaMagic { get; set; }
    }
}
