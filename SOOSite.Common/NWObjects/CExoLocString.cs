using System;
using System.Collections.Generic;
using SOOSite.Common.GffRawStructures;

namespace SOOSite.Common.NWObjects
{
    public class CExoLocString
    {
        public int StringRef { get; set; }
        public List<NWLocalizedString> LocalizedStrings { get; set; }

        public CExoLocString()
        {
            LocalizedStrings = new List<NWLocalizedString>();
        }

        public CExoLocString(GffElement element)
        {
            LocalizedStrings = new List<NWLocalizedString>();

            if (element == null) return;
            StringRef = Convert.ToInt32(element.Value);
            if (element.LocalizedStrings == null) return;

            foreach (var @string in element.LocalizedStrings)
            {
                LocalizedStrings.Add(new NWLocalizedString
                {
                    LanguageID = @string.LanguageId,
                    Text = @string.Value
                });
            }
        }
    }
}
