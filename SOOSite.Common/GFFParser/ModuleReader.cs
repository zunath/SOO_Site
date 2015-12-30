using SOOSite.Common.GFFParser;
using SOOSite.Common.NWObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOOSite.Common
{
    public class ModuleReader
    {
        BinaryReader reader;
        string fileType;
        string version;
        int languageCount;
        int localizedStringSize;
        int entryCount;
        int offsetToLocalizedString;
        int offsetToKeyList;
        int offsetToResourceList;
        int buildYear;
        int buildDay;
        int descriptionStrRef;
        byte[] reserved;
        List<NWLocalizedString> localizedModuleDescriptions;
        List<GffResource> resources;
        private NWModule _module;

        public ModuleReader()
        {
            localizedModuleDescriptions = new List<NWLocalizedString>();
            resources = new List<GffResource>();
        }

        public NWModule LoadModule(string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Open);
            reader = new BinaryReader(stream);
            _module = new NWModule();

            ReadHeader();
            ReadStrings();
            ReadResourceIndices();
            ReadResourceList();
            ReadResourceData();
            
            return _module;
        }

        private void ReadHeader()
        {
            fileType = Encoding.UTF8.GetString(reader.ReadBytes(4));
            version = Encoding.UTF8.GetString(reader.ReadBytes(4));
            languageCount = reader.ReadInt32();
            localizedStringSize = reader.ReadInt32();
            entryCount = reader.ReadInt32();
            offsetToLocalizedString = reader.ReadInt32();
            offsetToKeyList = reader.ReadInt32();
            offsetToResourceList = reader.ReadInt32();
            buildYear = reader.ReadInt32();
            buildDay = reader.ReadInt32();
            descriptionStrRef = reader.ReadInt32();
            reserved = reader.ReadBytes(116);
        }

        private void ReadStrings()
        {
            for(int i = 0; i < languageCount; i++)
            {
                NWLocalizedString locString = new NWLocalizedString();
                locString.LanguageID = reader.ReadInt32();
                int stringSize = reader.ReadInt32();
                locString.Text = Encoding.UTF8.GetString(reader.ReadBytes(stringSize));

                localizedModuleDescriptions.Add(locString);
            }
        }

        private void ReadResourceIndices()
        {
            for(int i = 0; i < entryCount; i++)
            {
                GffResource resource = new GffResource();
                resource.Resref = Encoding.UTF8.GetString(reader.ReadBytes(16)).TrimEnd(new char[] { (char)0 });
                resource.ResourceID = reader.ReadInt32();
                resource.ResourceType = (GffResourceType)reader.ReadInt16();
                reader.ReadInt16(); // Unused by Bioware

                resources.Add(resource);
            }
        }

        private void ReadResourceList()
        {
            reader.BaseStream.Seek(offsetToResourceList, SeekOrigin.Begin);

            for (int i = 0; i < entryCount; i++)
            {
                resources[i].OffsetToResource = reader.ReadInt32();
                resources[i].ResourceSize = reader.ReadInt32();
            }
        }
        
        private void ReadResourceData()
        {
            GffResourceType[] validTypes = {
                GffResourceType.IFO, GffResourceType.ARE, GffResourceType.GIC,
                GffResourceType.GIT, GffResourceType.UTC, GffResourceType.UTD,
                GffResourceType.UTE, GffResourceType.UTI, GffResourceType.UTP,
                GffResourceType.UTS, GffResourceType.UTM, GffResourceType.UTT,
                GffResourceType.UTW, GffResourceType.DLG, GffResourceType.JRL,
                GffResourceType.FAC, GffResourceType.ITP, GffResourceType.PTM,
                GffResourceType.PTT, GffResourceType.BIC };

            List<Gff> gffRecords = new List<Gff>();

            foreach(var resource in resources)
            {
                resource.Data = reader.ReadBytes(resource.ResourceSize);

                if(validTypes.Contains(resource.ResourceType))
                {
                    GffReader gffReader = new GffReader();

                    gffRecords.Add(gffReader.LoadGff(resource));
                }

            }

            Gff ifo = gffRecords.Find(x => x.ResourceType == GffResourceType.IFO);
            _module = _module.FromGff(ifo);

        }

    }
}
