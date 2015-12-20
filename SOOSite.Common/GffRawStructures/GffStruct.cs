using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SOOSite.Common.GffRawStructures
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GffStruct
    {
        [XmlElement("element")]
        public GffElement[] Elements { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int ID { get; set; }
    }
}