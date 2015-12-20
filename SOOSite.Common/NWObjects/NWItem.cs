using System;
using System.Collections.Generic;
using System.Linq;
using SOOSite.Common.GffRawStructures;

namespace SOOSite.Common.NWObjects
{
    public class NWItem : INWObject
    {
        public string FileName { get; set; }
        public uint AdditionalCost { get; set; }
        public int BaseItemID { get; set; }
        public byte Charges { get; set; }
        public uint Cost { get; set; }
        public bool IsCursed { get; set; }
        public CExoLocString IdentifiedDescription { get; set; }
        public CExoLocString UnidentifiedDescription { get; set; }
        public bool IsPlot { get; set; }
        public List<NWItemProperty> ItemProperties { get; set; }
        public ushort StackSize { get; set; }
        public bool IsStolen { get; set; }
        public CExoLocString Name { get; set; }
        public string Tag { get; set; }
        public string Resref { get; set; }

        public string Comment { get; set; }
        public byte PaletteID { get; set; }

        public NWItem()
        {
            ItemProperties = new List<NWItemProperty>();
        }

        public INWObject ToMappedObject(Gff data)
        {
            NWItem result = new NWItem
            {
                FileName = data.Name,
                AdditionalCost = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                BaseItemID = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "BaseItem").Value),
                Charges = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Cost = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "Cost").Value),
                IsCursed = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                IdentifiedDescription = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "DescIdentified")),
                UnidentifiedDescription = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "Description")),
                Name = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "LocalizedName")),
                IsPlot = data.Struct.Elements.Single(x => x.Name == "Plot").Value == "1",
                StackSize = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                IsStolen = data.Struct.Elements.Single(x => x.Name == "Stolen").Value == "1",
                Tag = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                Resref = data.Struct.Elements.Single(x => x.Name == "TemplateResRef").Value
            };

            GffElement propList = data.Struct.Elements.SingleOrDefault(x => x.Name == "PropertiesList");

            if (propList?.Struct != null && propList.Struct.Any())
            {
                GffStruct @struct = propList.Struct[0];
                result.ItemProperties.Add(new NWItemProperty
                {
                    CostTable = Convert.ToByte(@struct?.Elements.SingleOrDefault(x => x.Name == "CostTable")?.Value),
                    CostValue = Convert.ToUInt16(@struct?.Elements.SingleOrDefault(x => x.Name == "CostValue")?.Value),
                    Param1 = Convert.ToByte(@struct?.Elements.SingleOrDefault(x => x.Name == "Param1")?.Value),
                    Param1Value = Convert.ToByte(@struct?.Elements.SingleOrDefault(x => x.Name == "Param1Value")?.Value),
                    Param2 = Convert.ToByte(@struct?.Elements.SingleOrDefault(x => x.Name == "Param2")?.Value),
                    Param2Value = Convert.ToByte(@struct?.Elements.SingleOrDefault(x => x.Name == "Param2Value")?.Value),
                    PropertyName = Convert.ToUInt16(@struct?.Elements.SingleOrDefault(x => x.Name == "PropertyName")?.Value),
                    Subtype = Convert.ToUInt16(@struct?.Elements.SingleOrDefault(x => x.Name == "Subtype")?.Value),
                });

            }
            return result;
        }

    }
}
