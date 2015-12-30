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
            
            NWModule module = new NWModule();

            foreach (string label in source.Labels)
            {
                GffField field = GetFieldByLabel(source, label);

                switch (label)
                {
                    case "Expansion_Pack":
                        UsesHOTU = field.DataOrDataOffset == 3 || field.DataOrDataOffset == 2;
                        UsesSOU = field.DataOrDataOffset == 3 || field.DataOrDataOffset == 1;
                        break;
                    case "Mod_Area_List":
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
                        EntryDirectionX = (float)field.DoubleValue;
                        break;
                    case "Mod_Entry_Dir_Y":
                        EntryDirectionY = (float) field.DoubleValue;
                        break;
                    case "Mod_Entry_X":
                        EntryPositionX = (float)field.DoubleValue;
                        break;
                    case "Mod_Entry_Y":
                        EntryPositionY = (float)field.DoubleValue;
                        break;
                    case "Mod_Entry_Z":
                        EntryPositionZ = (float)field.DoubleValue;
                        break;
                    case "Mod_Expan_List":
                        break;
                    case "Mod_GVar_List":
                        break;
                    case "Mod_Hak":
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
