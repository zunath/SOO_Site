using System;
using System.Collections.Generic;
using SOOSite.Common.GFFParser;

namespace SOOSite.Common.NWObjects
{
    public class NWModule
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

        public NWModule()
        {
            Areas = new List<NWArea>();
            Items = new List<NWItem>();
        }

        public static NWModule FromGff(Gff source, List<Gff> areList, List<Gff> gitList, List<Gff> gicList   )
        {
            if(source.ResourceType != GffResourceType.IFO)
                throw new Exception("Source must be IFO resource type.");

            NWModule module = new NWModule();

            foreach (var entry in source.RootStruct)
            {
                string label = entry.Value.Label;
                GffField field = entry.Value;

                switch (label)
                {
                    case "Expansion_Pack":
                        module.UsesHOTU = field.ByteValue == 3 || field.ByteValue == 2;
                        module.UsesSOU = field.ByteValue == 3 || field.ByteValue == 1;
                        break;
                    case "Mod_Area_list":

                        for (int x = 0; x < areList.Count; x++)
                        {
                            Gff are = areList[x];
                            Gff git = gitList[x];
                            Gff gic = gicList[x];

                            module.Areas.Add(NWArea.FromGff(are, git, gic));
                        }

                        break;
                    case "Mod_CacheNSSList":
                        break;
                    case "Mod_Creator_ID":
                        module.CreatorID = field.IntValue;
                        break;
                    case "Mod_CustomTlk":
                        module.CustomTLK = field.StringValue;
                        break;
                    case "Mod_CutsceneList":
                        break;
                    case "Mod_DawnHour":
                        module.DawnHour = field.ByteValue;
                        break;
                    case "Mod_Description":
                        module.Description = field.LocalizedStrings[0];
                        break;
                    case "Mod_DuskHour":
                        module.DuskHour = field.ByteValue;
                        break;
                    case "Mod_Entry_Area":
                        module.EntryAreaResref = field.ResrefValue;
                        break;
                    case "Mod_Entry_Dir_X":
                        module.EntryDirectionX = field.FloatValue;
                        break;
                    case "Mod_Entry_Dir_Y":
                        module.EntryDirectionY = field.FloatValue;
                        break;
                    case "Mod_Entry_X":
                        module.EntryPositionX = field.FloatValue;
                        break;
                    case "Mod_Entry_Y":
                        module.EntryPositionY = field.FloatValue;
                        break;
                    case "Mod_Entry_Z":
                        module.EntryPositionZ = field.FloatValue;
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
                        module.ModuleID = BitConverter.ToInt32(field.VoidDataValue, 0);
                        break;
                    case "Mod_IsSaveGame":
                        module.IsSaveGame = Convert.ToBoolean(field.ByteValue);
                        break;
                    case "Mod_MinGameVer":
                        module.MinimumGameVersion = field.StringValue;
                        break;
                    case "Mod_MinPerHour":
                        module.MinutesPerHour = field.ByteValue;
                        break;
                    case "Mod_Name":
                        module.Name = field.LocalizedStrings[0];
                        break;
                    case "Mod_OnAcquirItem":
                        module.OnAcquireItem = field.ResrefValue;
                        break;
                    case "Mod_OnActvtItem":
                        module.OnActivateItem = field.ResrefValue;
                        break;
                    case "Mod_OnClientEntr":
                        module.OnClientEnter = field.ResrefValue;
                        break;
                    case "Mod_OnClientLeav":
                        module.OnClientLeave = field.ResrefValue;
                        break;
                    case "Mod_OnCutsnAbort":
                        module.OnCutsceneAbort = field.ResrefValue;
                        break;
                    case "Mod_OnHeartbeat":
                        module.OnHeartbeat = field.ResrefValue;
                        break;
                    case "Mod_OnModLoad":
                        module.OnModuleLoad = field.ResrefValue;
                        break;
                    case "Mod_OnModStart":
                        // Deprecated by Bioware
                        break;
                    case "Mod_OnPlrDeath":
                        module.OnPlayerDeath = field.ResrefValue;
                        break;
                    case "Mod_OnPlrDying":
                        module.OnPlayerDying = field.ResrefValue;
                        break;
                    case "Mod_OnPlrEqItm":
                        module.OnEquipItem = field.ResrefValue;
                        break;
                    case "Mod_OnPlrLvlUp":
                        module.OnLevelUp = field.ResrefValue;
                        break;
                    case "Mod_OnPlrRest":
                        module.OnPlayerRest = field.ResrefValue;
                        break;
                    case "Mod_OnPlrUnEqItm":
                        module.OnUnequipItem = field.ResrefValue;
                        break;
                    case "Mod_OnSpawnBtnDn":
                        module.OnPlayerRespawn = field.ResrefValue;
                        break;
                    case "Mod_OnUnAqreItem":
                        module.OnUnacquireItem = field.ResrefValue;
                        break;
                    case "Mod_OnUsrDefined":
                        module.OnUserDefined = field.ResrefValue;
                        break;
                    case "Mod_StartDay":
                        module.StartDay = field.ByteValue;
                        break;
                    case "Mod_StartHour":
                        module.StartHour = field.ByteValue;
                        break;
                    case "Mod_StartMonth":
                        module.StartMonth = field.ByteValue;
                        break;
                    case "Mod_StartMovie":
                        module.StartMovie = field.ResrefValue;
                        break;
                    case "Mod_StartYear":
                        module.StartYear = field.DWordValue;
                        break;
                    case "Mod_Tag":
                        module.Tag = field.StringValue;
                        break;
                    case "Mod_Version":
                        module.Version = field.DWordValue;
                        break;
                    case "Mod_XPScale":
                        module.XPScale = field.ByteValue;
                        break;

                }

            }



            return module;
        }

        public Gff ToGff()
        {
            throw new System.NotImplementedException();
        }
    }
}
