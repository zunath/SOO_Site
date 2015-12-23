namespace SOOSite.Data.Entities
{
    public class NWItem
    {
        public int NWItemID { get; set; }
        public string FileName { get; set; }
        public long AdditionalCost { get; set; }
        public int BaseItemID { get; set; }
        public byte Charges { get; set; }
        public long Cost { get; set; }
        public bool IsCursed { get; set; }
        public bool IsPlot { get; set; }
        public int StackSize { get; set; }
        public bool IsStolen { get; set; }
        public string Tag { get; set; }
        public string Resref { get; set; }
        public string Comment { get; set; }
        public byte PaletteID { get; set; }
        public long UnidentifiedDescriptionStringRef { get; set; }
        public long IdentifiedDescriptionStringRef { get; set; }
        public int NameLocalizedStringID { get; set; }
    }

}
