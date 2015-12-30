using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWWaypoint: INWObject<NWWaypoint>
    {
        public byte AppearanceID { get; set; }
        public NWLocalizedString Description { get; set; }
        public bool HasMapNote { get; set; }
        public string LinkedTo { get; set; }
        public NWLocalizedString LocalizedName { get; set; }
        public NWLocalizedString MapNote { get; set; }
        public bool IsMapNoteEnabled { get; set; }
        public string Tag { get; set; }
        public string Label { get; set; }
        public string Resref { get; set; }
        public int StrRef { get; set; }
        public string Comment { get; set; }
        public byte PaletteID { get; set; }
        public string TemplateResRef { get; set; }
        public float XOrientation { get; set; }
        public float YOrientation { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float ZPosition { get; set; }

        public NWWaypoint FromGff(Gff source)
        {
            NWWaypoint waypoint = new NWWaypoint
            {
                Resref = source.Resref
            };

            return waypoint;
        }

        public Gff ToGff()
        {
            throw new System.NotImplementedException();
        }
    }
}
