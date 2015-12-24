using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOOSite.Common
{
    public class GffResource
    {
        public string Resref { get; set; }
        public int ResourceID { get; set; }
        public int ResourceType { get; set; }
        public int OffsetToResource { get; set; }
        public int ResourceSize { get; set; }
        public byte[] Data { get; set; }
    }
}
