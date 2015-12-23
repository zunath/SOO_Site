namespace SOOSite.Data.Entities
{
    public class NWItemProperty
    {
        public int NWItemPropertyID { get; set; }
        public int NWItemID { get; set; }
        public byte CostTable { get; set; }
        public int CostValue { get; set; }
        public byte Param1 { get; set; }
        public byte Param1Value { get; set; }
        public byte Param2 { get; set; }
        public byte Param2Value { get; set; }
        public int PropertyName { get; set; }
        public int Subtype { get; set; }
    }

}
