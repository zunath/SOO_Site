using System;

namespace SOOSite.Common.Enums
{
    [Flags]
    public enum AreaFlagType: uint
    {
        None = 0x0000,
        Interior = 0x0001,
        Underground = 0x0002,
        Natural = 0x0004
    }
}
