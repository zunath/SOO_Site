using System.Collections.Generic;
using SOOSite.Common.NWObjects;

namespace SOOSite.Common.GFFParser
{
    public class Gff
    {
        public string Resref { get; set; }
        public GffResourceType ResourceType { get; set; }
        public List<GffStruct> Structs { get; set; }
        public List<GffField> Fields { get; set; }
        public List<string> Labels { get; set; } 
        public List<NWLocalizedString> LocalizedStrings { get; set; } 
        public List<uint> ListIndices { get; set; } 
        public List<byte[]> VoidData { get; set; } 
        public List<byte[]> FieldData { get; set; }

        public Gff()
        {
            Resref = string.Empty;
            ResourceType = GffResourceType.Invalid;
            
            Structs = new List<GffStruct>();
            Fields = new List<GffField>();
            Labels = new List<string>();
            LocalizedStrings = new List<NWLocalizedString>();
            ListIndices = new List<uint>();
            VoidData = new List<byte[]>();
            FieldData = new List<byte[]>();
        }
    }
}
