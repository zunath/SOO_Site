using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SOOSite.Common.GffRawStructures
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GffString
    {
        [XmlAttribute(AttributeName = "languageId")]
        public int LanguageId { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}