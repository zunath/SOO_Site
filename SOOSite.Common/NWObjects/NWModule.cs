using System;
using System.Collections.Generic;
using System.Linq;
using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWModule: NWObjectBase, INWObject<NWModule>
    {
        public bool UsesSOU { get; set; }
        public bool UsesHOTU { get; set; }
        public int CreatorID { get; set; }
        public string CustomTLK { get; set; }
        public byte DawnHour { get; set; }
        public byte DuskHour { get; set; }
        public byte StartDay { get; set; }
        public byte StartHour { get; set; }
        public byte StartMonth { get; set; }
        public uint StartYear { get; set; }
        public string StartMovie { get; set; }
        public string Tag { get; set; }
        public uint Version { get; set; }
        public byte XPScale { get; set; }

        public NWLocalizedString Description { get; set; }
        public string EntryAreaResref { get; set; }
        public float EntryDirectionX { get; set; }
        public float EntryDirectionY { get; set; }

        public float EntryPositionX { get; set; }
        public float EntryPositionY { get; set; }
        public float EntryPositionZ { get; set; }

        public int ModuleID { get; set; }
        public bool IsSaveGame { get; set; }
        public string MinimumGameVersion { get; set; }
        public byte MinutesPerHour { get; set; }
        public NWLocalizedString Name { get; set; }
        public string OnAcquireItem { get; set; }
        public string OnActivateItem { get; set; }
        public string OnClientEnter { get; set; }
        public string OnClientLeave { get; set; }
        public string OnCutsceneAbort { get; set; }
        public string OnHeartbeat { get; set; }
        public string OnModuleLoad { get; set; }
        public string OnPlayerDeath { get; set; }
        public string OnPlayerDying { get; set; }
        public string OnEquipItem { get; set; }
        public string OnLevelUp { get; set; }
        public string OnPlayerRest { get; set; }
        public string OnUnequipItem { get; set; }
        public string OnPlayerRespawn { get; set; }
        public string OnUnacquireItem { get; set; }
        public string OnUserDefined { get; set; }


        public List<NWLocalizedString> LocalizedModuleDescriptions { get; set; }
        public List<NWArea> Areas { get; set; }
        public List<NWItem> Items { get; set; }

        public NWModule FromGff(Gff source)
        {
            if(source.ResourceType != GffResourceType.IFO)
                throw new Exception("Source must be IFO resource type.");
            
            foreach (string label in source.Labels)
            {
                GffField field = GetFieldByLabel(source, label);

                switch (label)
                {
                    case "Expansion_Pack":
                        UsesHOTU = field.DataOrDataOffset == 3 || field.DataOrDataOffset == 2;
                        UsesSOU = field.DataOrDataOffset == 3 || field.DataOrDataOffset == 1;
                        break;
                    case "Mod_Area_list":
                        break;
                    case "Mod_CacheNSSList":
                        break;
                    case "Mod_Creator_ID":
                        CreatorID = (int)field.DataOrDataOffset;
                        break;
                    case "Mod_CustomTlk":
                        CustomTLK = field.StringValue;
                        break;
                    case "Mod_CutsceneList":
                        break;
                    case "Mod_DawnHour":
                        DawnHour = (byte)field.DataOrDataOffset;
                        break;
                    case "Mod_Description":
                        Description = field.LocalizedStrings[0];
                        break;
                    case "Mod_DuskHour":
                        DuskHour = (byte)field.DataOrDataOffset;
                        break;
                    case "Mod_Entry_Area":
                        EntryAreaResref = field.ResrefValue;
                        break;
                    case "Mod_Entry_Dir_X":
                        EntryDirectionX = field.DataOrDataOffset;
                        break;
                    case "Mod_Entry_Dir_Y":
                        EntryDirectionY = field.DataOrDataOffset;
                        break;
                    case "Mod_Entry_X":
                        EntryPositionX = field.DataOrDataOffset;
                        break;
                    case "Mod_Entry_Y":
                        EntryPositionY = field.DataOrDataOffset;
                        break;
                    case "Mod_Entry_Z":
                        EntryPositionZ = field.DataOrDataOffset;
                        break;
                    case "Mod_Expan_List":
                        // Deprecated by Bioware
                        break;
                    case "Mod_GVar_List":
                        // Deprecated by Bioware
                        break;
                    case "Mod_Hak":
                        // Obsolete by Bioware
                        break;
                    case "Mod_HakList":
                        break;
                    case "Mod_ID":
                        ModuleID = BitConverter.ToInt32(field.VoidDataValue, 0);
                        break;
                    case "Mod_IsSaveGame":
                        IsSaveGame = Convert.ToBoolean(field.DataOrDataOffset);
                        break;
                    case "Mod_MinGameVer":
                        MinimumGameVersion = field.StringValue;
                        break;
                    case "Mod_MinPerHour":
                        MinutesPerHour = (byte) field.DataOrDataOffset;
                        break;
                    case "Mod_Name":
                        Name = field.LocalizedStrings[0];
                        break;
                    case "Mod_OnAcquirItem":
                        OnAcquireItem = field.ResrefValue;
                        break;
                    case "Mod_OnActvtItem":
                        OnActivateItem = field.ResrefValue;
                        break;
                    case "Mod_OnClientEntr":
                        OnClientEnter = field.ResrefValue;
                        break;
                    case "Mod_OnClientLeav":
                        OnClientLeave = field.ResrefValue;
                        break;
                    case "Mod_OnCutsnAbort":
                        OnCutsceneAbort = field.ResrefValue;
                        break;
                    case "Mod_OnHeartbeat":
                        OnHeartbeat = field.ResrefValue;
                        break;
                    case "Mod_OnModLoad":
                        OnModuleLoad = field.ResrefValue;
                        break;
                    case "Mod_OnModStart":
                        // Deprecated by Bioware
                        break;
                    case "Mod_OnPlrDeath":
                        OnPlayerDeath = field.ResrefValue;
                        break;
                    case "Mod_OnPlrDying":
                        OnPlayerDying = field.ResrefValue;
                        break;
                    case "Mod_OnPlrEqItm":
                        OnEquipItem = field.ResrefValue;
                        break;
                    case "Mod_OnPlrLvlUp":
                        OnLevelUp = field.ResrefValue;
                        break;
                    case "Mod_OnPlrRest":
                        OnPlayerRest = field.ResrefValue;
                        break;
                    case "Mod_OnPlrUnEqItm":
                        OnUnequipItem = field.ResrefValue;
                        break;
                    case "Mod_OnSpawnBtnDn":
                        OnPlayerRespawn = field.ResrefValue;
                        break;
                    case "Mod_OnUnAqreItem":
                        OnUnacquireItem = field.ResrefValue;
                        break;
                    case "Mod_OnUsrDefined":
                        OnUserDefined = field.ResrefValue;
                        break;
                    case "Mod_StartDay":
                        StartDay = (byte) field.DataOrDataOffset;
                        break;
                    case "Mod_StartHour":
                        StartHour = (byte) field.DataOrDataOffset;
                        break;
                    case "Mod_StartMonth":
                        StartMonth = (byte) field.DataOrDataOffset;
                        break;
                    case "Mod_StartMovie":
                        StartMovie = field.ResrefValue;
                        break;
                    case "Mod_StartYear":
                        StartYear = field.DataOrDataOffset;
                        break;
                    case "Mod_Tag":
                        Tag = field.StringValue;
                        break;
                    case "Mod_Version":
                        Version = field.DataOrDataOffset;
                        break;
                    case "Mod_XPScale":
                        XPScale = (byte) field.DataOrDataOffset;
                        break;

                }
            }

            return this;
        }

        public Gff ToGff()
        {
            throw new System.NotImplementedException();
        }
    }
}
