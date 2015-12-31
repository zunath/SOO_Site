using System.Collections.Generic;

namespace SOOSite.Common.GFFParser
{
    public class GffStruct
    {
        public List<GffField> Fields { get; set; }

        public GffStruct()
        {
            Fields = new List<GffField>();
        }
    }
}
