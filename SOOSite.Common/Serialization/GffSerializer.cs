using System;
using System.IO;
using System.Xml.Serialization;
using SOOSite.Common.GffRawStructures;
using SOOSite.Common.NWObjects;

namespace SOOSite.Common.Serialization
{
    public static class GffSerializer
    {
        public static T Deserialize<T>(string filePath)
            where T : INWObject
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Gff));
            string data = File.ReadAllText(filePath);

            using (TextReader reader = new StringReader(data))
            {
                Gff gff = (Gff)serializer.Deserialize(reader);
                T instance = (T)Activator.CreateInstance(typeof(T));

                return (T)instance.ToMappedObject(gff);
            }
        }

    }
}
