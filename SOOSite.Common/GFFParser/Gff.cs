using System.Collections.Generic;

namespace SOOSite.Common.GFFParser
{
    public class Gff
    {
        public string Resref { get; set; }
        public GffResourceType ResourceType { get; set; }
        public List<GffField> Fields { get; set; }
        public List<string> Labels { get; set; } 

        public Gff()
        {
            Resref = string.Empty;
            ResourceType = GffResourceType.Invalid;
            
            Fields = new List<GffField>();
            Labels = new List<string>();
        }
    }
}
