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
        public bool Disarmable { get; set; }
        public List<NWEquipItem> EquipItemList { get; set; }
        public ushort FactionID { get; set; }
        public List<NWFeat> FeatList { get; set; }
        public CExoLocString FirstName { get; set; }
        public short fortbonus { get; set; }
        public byte Gender { get; set; }
        public byte GoodEvil { get; set; }
        public short HitPoints { get; set; }
        public byte Int { get; set; }
        public bool Interruptable { get; set; }
        public bool IsImmortal { get; set; }
        public bool IsPC { get; set; }
        public List<NWItem> ItemList { get; set; }
        public CExoLocString LastName { get; set; }
        public byte LawfulChaotic { get; set; }
        public bool Lootable { get; set; }
        public short MaxHitPoints { get; set; }
        public byte NaturalAC { get; set; }
        public bool NoPermDeath { get; set; }
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
        public byte StartingPackage { get; set; }
        public byte Str { get; set; }
        public string Subrace { get; set; }
        public string Tag { get; set; }
        public bool Tail { get; set; }
        public int WalkRate { get; set; }
        public short willbonus { get; set; }
        public bool Wings { get; set; }

        public INWObject ToMappedObject(Gff data)
        {
            NWCreature result = new NWCreature
            {
                FileName = data.Name,
                AppearanceType = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                BodyBag = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Cha = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                ChallengeRating = Convert.ToSingle(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                ClassList
                Con = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Conversation = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                CRAdjust = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "BaseItem").Value),
                CurrentHitPoints = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                DecayTime = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "Cost").Value),
                Diety = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                Description = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "DescIdentified")),
                Dex = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Disarmable = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                EquipItemList
                FactionID = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                FeatList
                FirstName = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "DescIdentified")),
                fortbonus = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                Gender = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                GoodEvil = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                HitPoints = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                Int = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Interruptable = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                IsImmortal = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                IsPC = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                ItemList
                LastName = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "DescIdentified")),
                LawfulChaotic = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Lootable = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                MaxHitPoints = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                NaturalAC = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                NoPermDeath = data.Struct.Elements.Single(x => x.Name == "Cursed").Value == "1",
                PerceptionRange = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Phenotype = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "BaseItem").Value),
                Plot = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                PortraitId = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                Race = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                refbonus = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                ScriptAttacked = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptDamaged = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptDeath = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptDialogue = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptDisturbed = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScripEndRound = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptHeartbeat = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptOnBlocked = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptOnNotice = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptRested = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptSpawn = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptSpellAt = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                ScriptuserDefine = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                SkillList
                SoundSetFile = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                SpecAbilityList
                StartingPackage = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Str = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                Subrace = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                Tag = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                Tail = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value),
                WalkRate = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "BaseItem").Value),
                willbonus = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "StackSize").Value),
                Wings = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Charges").Value)
            };
            return result;
        }

    }
}
