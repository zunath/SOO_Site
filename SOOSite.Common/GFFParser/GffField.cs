using System;
using System.Collections.Generic;
using System.Linq;
using SOOSite.Common.NWObjects;

namespace SOOSite.Common.GFFParser
{
    public class GffField
    {
        public GffFieldType FieldType { get; set; }
        public uint LabelIndex { get; set; }
        public uint DataOrDataOffset { get; set; }

        public long Int64Value { get; set; }
        public ulong DWord64Value { get; set; }
        public double DoubleValue { get; set; }
        public string ResrefValue { get; set; }
        public byte[] VoidDataValue { get; set; }
        public string StringValue { get; set; }
        public List<NWLocalizedString> LocalizedStrings { get; set; }
        public GffStruct StructValue { get; set; }
        public List<int> ListIndices { get; set; } 

        public bool IsComplexType
        {
            get
            {
                GffFieldType[] complexTypes =
                {
                    GffFieldType.DWord64,
                    GffFieldType.Int64,
                    GffFieldType.Double,
                    GffFieldType.CExoString,
                    GffFieldType.ResRef,
                    GffFieldType.CExoLocString,
                    GffFieldType.Void,
                    GffFieldType.Struct,
                    GffFieldType.List
                };

                return complexTypes.Contains(FieldType);
            }
        }

        public GffField()
        {
            LocalizedStrings = new List<NWLocalizedString>();
            ListIndices = new List<int>();
        }

    }
}
