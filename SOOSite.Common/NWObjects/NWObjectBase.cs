using System.Linq;
using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public abstract class NWObjectBase
    {
        public GffField GetFieldByLabel(Gff source, string label)
        {
            int labelIndex = source.Labels.FindIndex(x => x == label);
            GffField field = source.Fields.FirstOrDefault(x => x.LabelIndex == labelIndex);

            return field;
        }
    }
}
