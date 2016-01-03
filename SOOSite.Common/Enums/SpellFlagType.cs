using System;

namespace SOOSite.Common.Enums
{
    [Flags]
    public enum SpellFlagType: byte
    {
        Readied = 0x01,
        SpontaneouslyCast = 0x02,
        UnlimitedUse = 0x04
    }
}
