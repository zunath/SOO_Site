using System;
using System.Collections.Generic;
using System.Linq;
using SOOSite.Common.GffRawStructures;

namespace SOOSite.Common.NWObjects
{
    public class NWItem : INWObject
    {
        public string FileName { get; set; }
        public string TemplateResRef { get; set; }
        public uint race { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public uint appearanceType { get; set; }
        public uint gender { get; set; }
        public uint phenotype { get; set; }
        public uint portraitId { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string conversation { get; set; }
        public bool isPC { get; set; }
        public uint factionId { get; set; }
        public bool disarmable { get; set; }
        public string subrace { get; set; }
        public string deity { get; set; }
        public uint wingsNew { get; set; }
        public uint tailNew { get; set; }
        public uint soundSetFile { get; set; }
        public string plot { get; set; }
        public bool isImmortal { get; set; }
        public bool interruptable { get; set; }
        public bool lootable { get; set; }
        public bool noPermDeath { get; set; }
        public bool bodyBag { get; set; }
        public bool startingPackage { get; set; }
        public uint decayTime { get; set; }
        public uint armorPart_rFoot { get; set; }
        public uint bodyPart_lFoot { get; set; }
        public uint bodyPart_rShin { get; set; }
        public uint bodyPart_lShin { get; set; }
        public uint bodyPart_lThigh { get; set; }
        public uint bodyPart_rThigh { get; set; }
        public uint bodyPart_pelvis { get; set; }
        public uint bodyPart_torso { get; set; }
        public uint bodyPart_belt { get; set; }
        public uint bodyPart_neck { get; set; }
        public uint bodyPart_rfArm { get; set; }
        public uint bodyPart_lfArm { get; set; }
        public uint bodyPart_rBicep { get; set; }
        public uint bodyPart_lBicep { get; set; }
        public uint bodyPart_rShoul { get; set; }
        public uint bodyPart_lShoul { get; set; }
        public uint bodyPart_rHand { get; set; }
        public uint bodyPart_lHand { get; set; }
        public uint appearanceHead { get; set; }
        public uint colorSkin { get; set; }
        public uint colorHair { get; set; }
        public uint colorTattoo1 { get; set; }
        public uint colorTattoo2 { get; set; }
        public uint str { get; set; }
        public uint dex { get; set; }
        public uint con { get; set; }
        public uint intelligence { get; set; }
        public uint wis { get; set; }
        public uint cha { get; set; }
        public uint walkRate { get; set; }
        public uint naturalAC { get; set; }
        public uint hitpoints { get; set; }
        public uint currentHitpoints { get; set; }
        public uint maxHitpoints { get; set; }
        public uint refBonus { get; set; }
        public uint willBonus { get; set; }
        public uint fortBonus { get; set; }
        public uint goodEvil { get; set; }
        public uint lawfulChaotic { get; set; }
        public double challengeRating { get; set; }
        public uint crAdjust { get; set; }
        public uint perceptionRange { get; set; }
        public string scriptHeartbeat { get; set; }
        public string scriptOnNotice { get; set; }
        public string scriptSpellAt { get; set; }
        public string scriptAttacked { get; set; }
        public string scriptDamaged { get; set; }
        public string scriptDisturbed { get; set; }
        public string scriptEndRound { get; set; }
        public string scriptDialogue { get; set; }
        public string scriptSpawn { get; set; }
        public string scriptRested { get; set; }
        public string scriptDeath { get; set; }
        public string scriptUserDefine { get; set; }
        public string scriptOnBlocked { get; set; }
        public uint skillList { get; set; }
        public uint templateList { get; set; }
        public uint specAbilityList { get; set; }
        public uint classList { get; set; }
        public uint equipItemList { get; set; }
        public uint paletteId { get; set; }
        public string comment { get; set; }

        /*
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
        */

        public INWObject ToMappedObject(Gff data)
        {
            NWItem result = new NWItem
            {
                FileName = data.Name,
                /*
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
                */
            };
            return result;
        }

    }
}
