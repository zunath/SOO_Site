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
        private List<NWLocalizedString> fieldDataLocalizedStrings;
        private List<int> listIndices { get; set; }

        BinaryReader _reader;

        public GffReader()
        {
            structs = new List<GffStruct>();
            fields = new List<GffField>();
            labels = new List<string>();
            fieldDataRecords = new List<byte[]>();
            fieldDataLocalizedStrings = new List<NWLocalizedString>();
            listIndices = new List<int>();
        }

        public void LoadGff(GffResource resource)
        {
            _reader = new BinaryReader(new MemoryStream(resource.Data));
            
            ReadHeader();
            ReadStructs();
            ReadFields();
            ReadLabels();
            ReadFieldDataRecords();
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
                GffField field = new GffField();
                field.FieldType = (GffFieldType)_reader.ReadUInt32();
                field.LabelIndex = _reader.ReadUInt32();
                field.DataOrDataOffset = _reader.ReadUInt32();

                fields.Add(field);
            }
        }

        private void ReadLabels()
        {
            for(int i = 0; i < labelCount; i++)
            {
                string label = Encoding.UTF8.GetString(_reader.ReadBytes(16)).TrimEnd(new char[] { (char)0 });
                labels.Add(label);
            }
        }
        
        private void ReadFieldDataRecords()
        {
            foreach(var field in fields)
            {
                if(field.IsComplexType)
                {
                    switch(field.FieldType)
                    {
                        case GffFieldType.List:
                            _reader.BaseStream.Seek(listIndicesOffset + field.DataOrDataOffset, SeekOrigin.Begin);
                            break;
                        default:
                            _reader.BaseStream.Seek(fieldDataOffset + field.DataOrDataOffset, SeekOrigin.Begin);
                            break;
                    }
                    

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
                            bytesToRead = 16;
                            break;
                        case GffFieldType.CExoLocString:
                            uint totalSize = _reader.ReadUInt32();
                            uint stringRef = _reader.ReadUInt32();
                            uint stringCount = _reader.ReadUInt32();

                            for(int i = 0; i < stringCount; i++)
                            {
                                NWLocalizedString locString = new NWLocalizedString();
                                locString.LanguageID = _reader.ReadInt32();

                                int stringLength = _reader.ReadInt32();
                                byte[] stringBytes = _reader.ReadBytes(stringLength);
                                locString.Text = Encoding.UTF8.GetString(stringBytes);

                                fieldDataLocalizedStrings.Add(locString);
                            }
                            break;
                        case GffFieldType.Void:
                            break;
                        case GffFieldType.Struct:
                            GffStruct @struct = structs[(int)field.DataOrDataOffset];
                            break;
                        case GffFieldType.List:
                            uint listSize = _reader.ReadUInt32();

                            for(int i = 0; i < listSize; i++)
                            {
                                int listIndex = _reader.ReadInt32();
                                GffStruct listStruct = structs[listIndex];
                            }

                            break;
                    }

                    if(bytesToRead > 0)
                    {
                        byte[] data = _reader.ReadBytes(bytesToRead);
                        fieldDataRecords.Add(data);
                        string test = Encoding.UTF8.GetString(data);
                    }
                }
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

    }
}
