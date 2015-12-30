using System.Collections.Generic;
using SOOSite.Common.NWObjects;
using System.IO;
using System.Text;

namespace SOOSite.Common.GFFParser
{
    public class GffReader
    {
        private uint _structCount;
        private uint _fieldCount;
        private uint _labelCount;
        private uint _fieldDataOffset;
        private uint _listIndicesOffset;
        private readonly List<GffStruct> _structs;
        private Gff _result;

        BinaryReader _reader;

        public GffReader()
        {
            _structs = new List<GffStruct>();
        }

        public Gff LoadGff(GffResource resource)
        {
            _result = new Gff
            {
                ResourceType = resource.ResourceType,
                Resref = resource.Resref
            };
            _reader = new BinaryReader(new MemoryStream(resource.Data));
            
            ReadHeader();
            ReadStructs();
            ReadFields();
            ReadLabels();
            ReadFieldDataRecords();

            return _result;
        }
        
        private void ReadHeader()
        {
            _reader.ReadBytes(4); // FileType
            _reader.ReadBytes(4); // FileVersion
            _reader.ReadUInt32(); // StructOffset
            _structCount = _reader.ReadUInt32();
            _reader.ReadUInt32(); // FieldOffset
            _fieldCount = _reader.ReadUInt32();
            _reader.ReadUInt32(); // LabelOffset
            _labelCount = _reader.ReadUInt32();
            _fieldDataOffset = _reader.ReadUInt32();
            _reader.ReadUInt32(); // FieldDataCount
            _reader.ReadUInt32(); // FieldIndicesOffset
            _reader.ReadUInt32(); // FieldIndicesCount
            _listIndicesOffset = _reader.ReadUInt32(); 
            _reader.ReadUInt32(); // ListIndicesCount
        }

        private void ReadStructs()
        {
            for(int i = 0; i < _structCount; i++)
            {
                _structs.Add(ReadStruct());
            }
        }

        private void ReadFields()
        {
            for(int i = 0; i < _fieldCount; i++)
            {
                GffField field = new GffField
                {
                    FieldType = (GffFieldType) _reader.ReadUInt32(),
                    LabelIndex = _reader.ReadUInt32(),
                    DataOrDataOffset = _reader.ReadUInt32()
                };

                _result.Fields.Add(field);
            }
        }

        private void ReadLabels()
        {
            for(int i = 0; i < _labelCount; i++)
            {
                _result.Labels.Add(Encoding.UTF8.GetString(_reader.ReadBytes(16)).TrimEnd((char)0));
            }
        }
        
        private void ReadFieldDataRecords()
        {
            _reader.BaseStream.Seek(_fieldDataOffset, SeekOrigin.Begin);

            foreach (var field in _result.Fields)
            {
                if (!field.IsComplexType) continue;
                
                switch(field.FieldType)
                {
                    case GffFieldType.DWord64:
                        field.DWord64Value = _reader.ReadUInt64();
                        break;
                    case GffFieldType.Int64:
                        field.Int64Value = _reader.ReadInt64();
                        break;
                    case GffFieldType.Double:
                        field.DoubleValue = _reader.ReadDouble();
                        break;
                    case GffFieldType.CExoString:
                        uint stringSize = _reader.ReadUInt32();
                        byte[] stringData = new byte[stringSize];
                        
                        for (int i = 0; i < stringSize; i++)
                        {
                            stringData[i] = _reader.ReadByte();
                        }
                        field.StringValue = Encoding.UTF8.GetString(stringData);

                        break;
                    case GffFieldType.ResRef:
                        byte resrefStringSize = _reader.ReadByte();
                        field.ResrefValue = Encoding.UTF8.GetString(_reader.ReadBytes(resrefStringSize));
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

                            field.LocalizedStrings.Add(locString);
                        }
                        break;
                    case GffFieldType.Void:
                        uint size = _reader.ReadUInt32();
                        byte[] data = new byte[size];
                        for (int i = 0; i < size; i++)
                        {
                            data[i] = _reader.ReadByte();
                        }
                        field.VoidDataValue = data;
                        break;
                    case GffFieldType.Struct:
                        field.StructValue = _structs[(int)field.DataOrDataOffset];
                        break;
                    case GffFieldType.List:
                        long backupPosition = _reader.BaseStream.Position;
                        _reader.BaseStream.Seek(_listIndicesOffset + field.DataOrDataOffset, SeekOrigin.Begin);
                        uint listCount = _reader.ReadUInt32();

                        for (int i = 0; i < listCount; i++)
                        {
                            field.ListIndices.Add((int)_reader.ReadUInt32());
                        }

                        _reader.BaseStream.Position = backupPosition;
                        break;
                }
            }
        }


        private GffStruct ReadStruct()
        {
            GffStruct str = new GffStruct
            {
                StructType = _reader.ReadUInt32(),
                DataOrDataOffset = _reader.ReadUInt32(),
                FieldCount = _reader.ReadUInt32()
            };

            return str;
        }
    }
}
