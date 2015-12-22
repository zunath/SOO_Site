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
        public List<NWItem> ItemList { get; set; } //todo: inventory object instead of nwitem?
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
        public byte Tail { get; set; }
        public int WalkRate { get; set; }
        public short willbonus { get; set; }
        public byte Wings { get; set; }

        public INWObject ToMappedObject(Gff data)
        {
            NWCreature result = new NWCreature
            {
                //TODO: create objects for lists
                FileName = data.Name,
                AppearanceType = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "Appearance_Type").Value),
                BodyBag = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "BodyBag").Value),
                Cha = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Cha").Value),
                ChallengeRating = Convert.ToSingle(data.Struct.Elements.Single(x => x.Name == "ChallengeRating").Value),
                ClassList
                Con = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Con").Value),
                Conversation = data.Struct.Elements.Single(x => x.Name == "Conversation").Value,
                CRAdjust = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "CRAdjust").Value),
                CurrentHitPoints = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "CurrentHitPoints").Value),
                DecayTime = Convert.ToUInt32(data.Struct.Elements.Single(x => x.Name == "DecayTime").Value),
                Diety = data.Struct.Elements.Single(x => x.Name == "Deity").Value,
                Description = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "Description")),
                Dex = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Dex").Value),
                Disarmable = data.Struct.Elements.Single(x => x.Name == "Disarmable").Value == "1",
                EquipItemList
                FactionID = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "FactionID").Value),
                FeatList
                FirstName = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "FirstName")),
                fortbonus = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "fortbonus").Value),
                Gender = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Gender").Value),
                GoodEvil = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "GoodEvil").Value),
                HitPoints = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "HitPoints").Value),
                Int = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Int").Value),
                Interruptable = data.Struct.Elements.Single(x => x.Name == "Interruptable").Value == "1",
                IsImmortal = data.Struct.Elements.Single(x => x.Name == "IsImmortal").Value == "1",
                IsPC = data.Struct.Elements.Single(x => x.Name == "IsPC").Value == "1",
                ItemList
                LastName = new CExoLocString(data.Struct.Elements.SingleOrDefault(x => x.Name == "LastName")),
                LawfulChaotic = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "LawfulChaotic").Value),
                Lootable = data.Struct.Elements.Single(x => x.Name == "Lootable").Value == "1",
                MaxHitPoints = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "MaxHitPoints").Value),
                NaturalAC = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "NaturalAC").Value),
                NoPermDeath = data.Struct.Elements.Single(x => x.Name == "NoPermDeath").Value == "1",
                PerceptionRange = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "PerceptionRange").Value),
                Phenotype = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "Phenotype").Value),
                Plot = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Plot").Value),
                PortraitId = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "PortraitId").Value),
                Race = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Race").Value),
                refbonus = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "refbonus").Value),
                ScriptAttacked = data.Struct.Elements.Single(x => x.Name == "ScriptAttacked").Value,
                ScriptDamaged = data.Struct.Elements.Single(x => x.Name == "ScriptDamaged").Value,
                ScriptDeath = data.Struct.Elements.Single(x => x.Name == "ScriptDeath").Value,
                ScriptDialogue = data.Struct.Elements.Single(x => x.Name == "ScriptDialogue").Value,
                ScriptDisturbed = data.Struct.Elements.Single(x => x.Name == "ScriptDisturbed").Value,
                ScripEndRound = data.Struct.Elements.Single(x => x.Name == "ScriptEndRound").Value,
                ScriptHeartbeat = data.Struct.Elements.Single(x => x.Name == "ScriptHeartbeat").Value,
                ScriptOnBlocked = data.Struct.Elements.Single(x => x.Name == "ScriptOnBlocked").Value,
                ScriptOnNotice = data.Struct.Elements.Single(x => x.Name == "ScriptOnNotice").Value,
                ScriptRested = data.Struct.Elements.Single(x => x.Name == "ScriptRested").Value,
                ScriptSpawn = data.Struct.Elements.Single(x => x.Name == "ScriptSpawn").Value,
                ScriptSpellAt = data.Struct.Elements.Single(x => x.Name == "ScriptSpellAt").Value,
                ScriptuserDefine = data.Struct.Elements.Single(x => x.Name == "SciptuserDefine").Value,
                SkillList
                SoundSetFile = Convert.ToUInt16(data.Struct.Elements.Single(x => x.Name == "SoundSetFile").Value),
                SpecAbilityList
                StartingPackage = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "StartingPackage").Value),
                Str = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Str").Value),
                Subrace = data.Struct.Elements.Single(x => x.Name == "Subrace").Value,
                Tag = data.Struct.Elements.Single(x => x.Name == "Tag").Value,
                Tail = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Tail").Value),
                WalkRate = Convert.ToInt32(data.Struct.Elements.Single(x => x.Name == "WalkRate").Value),
                willbonus = Convert.ToInt16(data.Struct.Elements.Single(x => x.Name == "wilbonus").Value),
                Wings = Convert.ToByte(data.Struct.Elements.Single(x => x.Name == "Wings").Value)
            };
            return result;
        }

    }
}
