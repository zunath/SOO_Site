using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SOOSite.Common.GffRawStructures
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GffElement
    {
        [XmlElement("struct")]
        public GffStruct[] Struct { get; set; }

        [XmlElement("localString")]
        public GffString[] LocalizedStrings { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public int Type { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}