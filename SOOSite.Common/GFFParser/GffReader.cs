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

        BinaryReader _reader;

        public GffReader()
        {

        }

        public void LoadGff(GffResource resource)
        {
            _reader = new BinaryReader(new MemoryStream(resource.Data));

            ReadHeader();

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

    }
}
