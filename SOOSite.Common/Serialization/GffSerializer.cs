using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SOOSite.Common.GffRawStructures;
using SOOSite.Common.NWObjects;

namespace SOOSite.Common.Serialization
{
    public static class GffSerializer
    {
        private static Dictionary<string, Type> ExtensionMapper;

        static GffSerializer()
        {
            ExtensionMapper = new Dictionary<string, Type>
            {
                {".uti", typeof (NWItem)},
                {".utc", typeof(NWCreature)}
            };
        }

        public static INWObject Deserialize(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Gff));
            string data = File.ReadAllText(filePath);
            string extension = Path.GetExtension(filePath);
            if (extension == ".xml")
            {
                extension = Path.GetExtension(filePath.Substring(0, filePath.Length - 4));
            }
            if (string.IsNullOrEmpty(extension) || 
                !ExtensionMapper.ContainsKey(extension))
            {
                throw new ArgumentException("Invalid or unsupported file extension type.");
            }


            Type type = ExtensionMapper[extension];

            using (TextReader reader = new StringReader(data))
            {
                Gff gff = (Gff)serializer.Deserialize(reader);
                INWObject instance = (INWObject)Activator.CreateInstance(type);
                return instance.ToMappedObject(gff);
            }
        }

    }
}
