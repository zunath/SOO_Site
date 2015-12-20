namespace SOOSite.Data.Entities
{
    public class NWLocalizedString
    {
        public int NWLocalizedStringID { get; set; }
        public int LanguageID { get; set; }
        public string Text { get; set; }
        public int? NWItemDescriptionID { get; set; }
        public bool NWItemDescriptionIsIdentified { get; set; }
    }

}
