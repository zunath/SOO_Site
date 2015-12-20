using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SOOSite.Common.GffRawStructures
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "gff", Namespace = "", IsNullable = false)]
    public class Gff
    {
        [XmlElement("struct")]
        public GffStruct Struct { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
}