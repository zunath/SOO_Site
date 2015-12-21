using System;
using System.Collections.Generic;
using System.Linq;
using SOOSite.Common.GffRawStructures;

namespace SOOSite.Common.NWObjects
{
    public class NWCreature : INWObject
    {
        public string FileName { get; set; }
        public ushort AppearanceType { get; set; }
        public byte BodyBag { get; set; }
        public byte Cha { get; set; }
        public float ChallengeRating { get; set; }
        public List<NWClass> ClassList { get; set; }
        public byte Con { get; set; }
        public string Conversation { get; set; }
        public int CRAdjust { get; set; }
        public short CurrentHitPoints { get; set; }
        public uint DecayTime { get; set; }
        public string Diety { get; set; }
        public CExoLocString Description { get; set; }
        public byte Dex { get; set; }
        public byte Disarmable { get; set; }
        public List<NWEquipItem> EquipItemList { get; set; }
        public ushort FactionID { get; set; }
        public List<NWFeat> FeatList { get; set; }
        public CExoLocString FirstName { get; set; }
        public short fortbonus { get; set; }
        public byte Gender { get; set; }
        public byte GoodEvil { get; set; }
        public short HitPoints { get; set; }
        public byte Int { get; set; }
        public byte Interruptable { get; set; }
        public byte IsImmortal { get; set; }
        public byte IsPC { get; set; }
        public List<NWItem> ItemList { get; set; }
        public CExoLocString LastName { get; set; }
        public byte LawfulChaotic { get; set; }
        public byte Lootable { get; set; }
        public short MaxHitPoints { get; set; }
        public byte NaturalAC { get; set; }
        public byte NoPermDeath { get; set; }
        public byte PerceptionRange { get; set; }
        public int Phenotype { get; set; }
        public byte Plot { get; set; }
        public ushort PortraitId { get; set; }
        public byte Race { get; set; }
        public short refbonus { get; set; }
        public string ScriptAttacked { get; set; }
        public string ScriptDamaged { get; set; }
        public string ScriptDeath { get; set; }
        public string ScriptDialogue { get; set; }
        public string ScriptDisturbed { get; set; }
        public string ScripEndRound { get; set; }
        public string ScriptHeartbeat { get; set; }
        public string ScriptOnBlocked { get; set; }
        public string ScriptOnNotice { get; set; }
        public string ScriptRested { get; set; }
        public string ScriptSpawn { get; set; }
        public string ScriptSpellAt { get; set; }
        public string ScriptuserDefine { get; set; }
        public List<NWSkill> SkillList { get; set; }
        public ushort SoundSetFile { get; set; }
        public List<NWSpecAbility> SpecAbilityList { get; set; }
        public byte StartingPAckage { get; set; }
        public byte Str { get; set; }
        public string Subrace { get; set; }
        public string Tag { get; set; }
        public byte Tail { get; set; }
        public int WalkRate { get; set; }
        public short willbonus { get; set; }
        public byte Wings { get; set; }

        public INWObject ToMappedObject(Gff data)
        {
            NWItem result = new NWItem
            {
                /*
                 FileName = data.Name,
                 TemplateResRef = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 race = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),  
                 firstName = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 lastName = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 appearanceType = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 gender = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 phenotype = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 portraitId = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 description = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 tag = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 conversation = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 isPC = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 factionId = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 disarmable = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 subrace = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 deity = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 wingsNew = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 tailNew = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 soundSetFile = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 plot = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 isImmortal = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 interruptable = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 lootable = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 noPermDeath = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyBag = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 startingPackage = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 decayTime = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 armorPart_rFoot = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lFoot = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_rShin = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lShin = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lThigh = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_rThigh = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_pelvis = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_torso = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_belt = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_neck = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_rfArm = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lfArm = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_rBicep = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lBicep = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_rShoul = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lShoul = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_rHand = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 bodyPart_lHand = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 appearanceHead = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 colorSkin = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 colorHair = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 colorTattoo1 = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 colorTattoo2 = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 str = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 dex = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 con = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 intelligence = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 wis = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 cha = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 walkRate = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 naturalAC = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 hitpoints = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 currentHitpoints = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 maxHitpoints = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 refBonus = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 willBonus = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 fortBonus = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 goodEvil = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 lawfulChaotic = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 challengeRating = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 crAdjust = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 perceptionRange = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 scriptHeartbeat = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptOnNotice = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptSpellAt = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptAttacked = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptDamaged = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptDisturbed = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptEndRound = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptDialogue = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptSpawn = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptRested = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptDeath = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptUserDefine = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 scriptOnBlocked = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                 skillList = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 templateList = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 specAbilityList = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 classList = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 equipItemList = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 paletteId = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "AddCost").Value),
                 comment = data.Struct.Elements.Single(x => x.Name == "Tag").Value
                 */
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
