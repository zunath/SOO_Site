using System.Collections.Generic;
using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWItem
    {
        public string FileName { get; set; }
        public uint AdditionalCost { get; set; }
        public int BaseItemID { get; set; }
        public byte Charges { get; set; }
        public uint Cost { get; set; }
        public bool IsCursed { get; set; }
        //public CExoLocString IdentifiedDescription { get; set; }
        //public CExoLocString UnidentifiedDescription { get; set; }
        public bool IsPlot { get; set; }
        public List<NWItemProperty> ItemProperties { get; set; }
        public ushort StackSize { get; set; }
        public bool IsStolen { get; set; }
        //public CExoLocString Name { get; set; }
        public string Tag { get; set; }
        public string Resref { get; set; }

        public string Comment { get; set; }
        public byte PaletteID { get; set; }

        public NWItem()
        {
            ItemProperties = new List<NWItemProperty>();
        }


        public static NWItem FromGff(GffStruct source)
        {
            NWItem item = new NWItem();

            return item;
        }

        public Gff ToGff()
        {
            throw new System.NotImplementedException();
        }
    }
}
