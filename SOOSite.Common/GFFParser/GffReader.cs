using SOOSite.Common.NWObjects;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOOSite.Common.GFFParser
{
    public class GffReader
    {
        private string fileType;
        private string fileVersion;
        private uint structOffset;
        private uint structCount;
        private uint fieldOffset;
        private uint fieldCount;
        private uint labelOffset;
        private uint labelCount;
        private uint fieldDataOffset;
        private uint fieldDataCount;
        private uint fieldIndicesOffset;
        private uint fieldIndicesCount;
        private uint listIndicesOffset;
        private uint listIndicesCount;
        private List<GffStruct> structs;
        private List<GffField> fields;
        private List<string> labels;
        private List<byte[]> fieldDataRecords;
        private List<byte[]> voidData; 
        private List<NWLocalizedString> fieldDataLocalizedStrings;
        private List<uint> listIndices { get; set; }
        private GffResource _resource;

        BinaryReader _reader;

        public GffReader()
        {
            structs = new List<GffStruct>();
            fields = new List<GffField>();
            labels = new List<string>();
            fieldDataRecords = new List<byte[]>();
            voidData = new List<byte[]>();
            fieldDataLocalizedStrings = new List<NWLocalizedString>();
            listIndices = new List<uint>();
        }

        public Gff LoadGff(GffResource resource)
        {
            _reader = new BinaryReader(new MemoryStream(resource.Data));
            _resource = resource;
            
            ReadHeader();
            ReadStructs();
            ReadFields();
            ReadLabels();
            ReadListIndices();
            ReadFieldDataRecords();

            return BuildGff();
        }
        
        private void ReadHeader()
        {
            fileType = Encoding.UTF8.GetString(_reader.ReadBytes(4));
            fileVersion = Encoding.UTF8.GetString(_reader.ReadBytes(4));
            structOffset = _reader.ReadUInt32();
            structCount = _reader.ReadUInt32();
            fieldOffset = _reader.ReadUInt32();
            fieldCount = _reader.ReadUInt32();
            labelOffset = _reader.ReadUInt32();
            labelCount = _reader.ReadUInt32();
            fieldDataOffset = _reader.ReadUInt32();
            fieldDataCount = _reader.ReadUInt32();
            fieldIndicesOffset = _reader.ReadUInt32();
            fieldIndicesCount = _reader.ReadUInt32();
            listIndicesOffset = _reader.ReadUInt32();
            listIndicesCount = _reader.ReadUInt32();
        }

        private void ReadStructs()
        {
            for(int i = 0; i < structCount; i++)
            {
                structs.Add(ReadStruct());
            }
        }

        private void ReadFields()
        {
            for(int i = 0; i < fieldCount; i++)
            {
                GffField field = new GffField
                {
                    FieldType = (GffFieldType) _reader.ReadUInt32(),
                    LabelIndex = _reader.ReadUInt32(),
                    DataOrDataOffset = _reader.ReadUInt32()
                };

                fields.Add(field);
            }
        }

        private void ReadLabels()
        {
            for(int i = 0; i < labelCount; i++)
            {
                string label = Encoding.UTF8.GetString(_reader.ReadBytes(16)).TrimEnd((char)0);
                labels.Add(label);
            }
        }

        private void ReadListIndices()
        {
            _reader.BaseStream.Seek(listIndicesOffset, SeekOrigin.Begin);

            if (listIndicesOffset >= _resource.ResourceSize) return;

            uint size = _reader.ReadUInt32();

            for (uint i = 0; i < size; i++)
            {
                listIndices.Add(_reader.ReadUInt32());
            }
        }

        private void ReadFieldDataRecords()
        {
            _reader.BaseStream.Seek(fieldDataOffset, SeekOrigin.Begin);

            foreach (var field in fields)
            {
                if (!field.IsComplexType) continue;
                int bytesToRead = 0;

                switch(field.FieldType)
                {
                    case GffFieldType.DWord64:
                    case GffFieldType.Int64:
                    case GffFieldType.Double:
                        bytesToRead = 8;
                        break;
                    case GffFieldType.CExoString:
                        uint stringSize = _reader.ReadUInt32();
                        bytesToRead = (int)stringSize;
                            
                        break;
                    case GffFieldType.ResRef:
                        bytesToRead = _reader.ReadByte();
                        break;
                    case GffFieldType.CExoLocString:
                        _reader.ReadUInt32(); // TotalSize
                        _reader.ReadUInt32(); // StringRef
                        uint stringCount = _reader.ReadUInt32();

                        for(int i = 0; i < stringCount; i++)
                        {
                            NWLocalizedString locString = new NWLocalizedString
                            {
                                LanguageID = _reader.ReadInt32()
                            };

                            int stringLength = _reader.ReadInt32();
                            byte[] stringBytes = _reader.ReadBytes(stringLength);
                            locString.Text = Encoding.UTF8.GetString(stringBytes);

                            fieldDataLocalizedStrings.Add(locString);
                        }
                        break;
                    case GffFieldType.Void:
                        uint size = _reader.ReadUInt32();
                        voidData.Add(_reader.ReadBytes((int) size));
                        break;
                }

                if (bytesToRead <= 0) continue;
                byte[] data = _reader.ReadBytes(bytesToRead);
                fieldDataRecords.Add(data);
            }
        }


        private GffStruct ReadStruct()
        {
            GffStruct str = new GffStruct();
            str.StructType = _reader.ReadUInt32();
            str.DataOrDataOffset = _reader.ReadUInt32();
            str.FieldCount = _reader.ReadUInt32();

            return str;
        }

        private Gff BuildGff()
        {
            Gff gff = new Gff
            {
                ResourceType = _resource.ResourceType,
                Resref = _resource.Resref,
                Fields = fields,
                Labels = labels,
                ListIndices = listIndices,
                LocalizedStrings = fieldDataLocalizedStrings,
                Structs = structs,
                VoidData = voidData
            };

            return gff;
        }

    }
}
