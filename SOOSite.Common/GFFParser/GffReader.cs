using SOOSite.Common.NWObjects;
using System.Collections.Generic;
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
        private GffResource _resource;
        private Gff _result;

        BinaryReader _reader;
        
        public Gff LoadGff(GffResource resource)
        {
            _result = new Gff();
            _reader = new BinaryReader(new MemoryStream(resource.Data));
            _resource = resource;
            
            ReadHeader();
            ReadStructs();
            ReadFields();
            ReadLabels();
            ReadListIndices();
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
                _result.Structs.Add(ReadStruct());
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
                string label = Encoding.UTF8.GetString(_reader.ReadBytes(16)).TrimEnd((char)0);
                _result.Labels.Add(label);
            }
        }

        private void ReadListIndices()
        {
            _reader.BaseStream.Seek(_listIndicesOffset, SeekOrigin.Begin);

            if (_listIndicesOffset >= _resource.ResourceSize) return;

            uint size = _reader.ReadUInt32();

            for (uint i = 0; i < size; i++)
            {
                _result.ListIndices.Add(_reader.ReadUInt32());
            }
        }

        private void ReadFieldDataRecords()
        {
            _reader.BaseStream.Seek(_fieldDataOffset, SeekOrigin.Begin);

            foreach (var field in _result.Fields)
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

                            _result.LocalizedStrings.Add(locString);
                        }
                        break;
                    case GffFieldType.Void:
                        uint size = _reader.ReadUInt32();
                        _result.VoidData.Add(_reader.ReadBytes((int) size));
                        break;
                }

                if (bytesToRead <= 0) continue;
                byte[] data = _reader.ReadBytes(bytesToRead);
                _result.FieldData.Add(data);
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
