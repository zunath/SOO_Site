using System.Data.Entity;
using SOOSite.Data.Entities;

namespace SOOSite.Data.Contexts
{
    public class SOOContext : DbContext
    {
        public SOOContext()
            : base("name=SOOEntities")
        {
        }

        public virtual DbSet<AuthorizedDM> AuthorizedDMs { get; set; }
        public virtual DbSet<BaseItemType> BaseItemTypes { get; set; }
        public virtual DbSet<BuildPrivacyDomain> BuildPrivacyDomains { get; set; }
        public virtual DbSet<CharacterClass> CharacterClasses { get; set; }
        public virtual DbSet<ClassAbility> ClassAbilities { get; set; }
        public virtual DbSet<ClassFeatLevel> ClassFeatLevels { get; set; }
        public virtual DbSet<ClassLevel> ClassLevels { get; set; }
        public virtual DbSet<ClassStat> ClassStats { get; set; }
        public virtual DbSet<ConstructionSite> ConstructionSites { get; set; }
        public virtual DbSet<CraftBlueprintCategory> CraftBlueprintCategories { get; set; }
        public virtual DbSet<CraftBlueprintComponent> CraftBlueprintComponents { get; set; }
        public virtual DbSet<CraftBlueprint> CraftBlueprints { get; set; }
        public virtual DbSet<CraftLevel> CraftLevels { get; set; }
        public virtual DbSet<Craft> Crafts { get; set; }
        public virtual DbSet<DMRoleDomain> DMRoleDomains { get; set; }
        public virtual DbSet<FactionRelationship> FactionRelationships { get; set; }
        public virtual DbSet<FactionRelationshipType> FactionRelationshipTypes { get; set; }
        public virtual DbSet<Faction> Factions { get; set; }
        public virtual DbSet<KeyItemCategory> KeyItemCategories { get; set; }
        public virtual DbSet<KeyItem> KeyItems { get; set; }
        public virtual DbSet<NPC> NPCs { get; set; }
        public virtual DbSet<NWItem> NWItems { get; set; }
        public virtual DbSet<NWItemProperty> NWItemProperties { get; set; }
        public virtual DbSet<NWLanguagesDomain> NWLanguagesDomain { get; set; }
        public virtual DbSet<NWLocalizedString> NWLocalizedStrings { get; set; }
        public virtual DbSet<PCAuthorizedCDKey> PCAuthorizedCDKeys { get; set; }
        public virtual DbSet<PCBlueprint> PCBlueprints { get; set; }
        public virtual DbSet<PCClass> PCClasses { get; set; }
        public virtual DbSet<PCCraft> PCCrafts { get; set; }
        public virtual DbSet<PCFactionReputation> PCFactionReputations { get; set; }
        public virtual DbSet<PCKeyItem> PCKeyItems { get; set; }
        public virtual DbSet<PCMigrationItem> PCMigrationItems { get; set; }
        public virtual DbSet<PCMigration> PCMigrations { get; set; }
        public virtual DbSet<PCOutfit> PCOutfits { get; set; }
        public virtual DbSet<PCOverflowItem> PCOverflowItems { get; set; }
        public virtual DbSet<PCSystemVersion> PCSystemVersions { get; set; }
        public virtual DbSet<PCTerritoryFlag> PCTerritoryFlags { get; set; }
        public virtual DbSet<PCTerritoryFlagsPermission> PCTerritoryFlagsPermissions { get; set; }
        public virtual DbSet<PCTerritoryFlagsStructure> PCTerritoryFlagsStructures { get; set; }
        public virtual DbSet<PCTerritoryFlagsStructuresItem> PCTerritoryFlagsStructuresItems { get; set; }
        public virtual DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual DbSet<Portrait> Portraits { get; set; }
        public virtual DbSet<PWData> PWDatas { get; set; }
        public virtual DbSet<PWObjData> PWObjDatas { get; set; }
        public virtual DbSet<ServerConfiguration> ServerConfigurations { get; set; }
        public virtual DbSet<StorageContainer> StorageContainers { get; set; }
        public virtual DbSet<StorageItem> StorageItems { get; set; }
        public virtual DbSet<StructureBlueprint> StructureBlueprints { get; set; }
        public virtual DbSet<StructureCategory> StructureCategories { get; set; }
        public virtual DbSet<TerritoryFlagPermission> TerritoryFlagPermissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseItemType>()
                .HasMany(e => e.PCMigrationItems)
                .WithRequired(e => e.BaseItemType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BuildPrivacyDomain>()
                .HasMany(e => e.PCTerritoryFlags)
                .WithRequired(e => e.BuildPrivacyDomain)
                .HasForeignKey(e => e.BuildPrivacySettingID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacterClass>()
                .Property(e => e.Callsign)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CharacterClass>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CharacterClass>()
                .HasMany(e => e.ClassFeatLevels)
                .WithRequired(e => e.CharacterClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacterClass>()
                .HasMany(e => e.ClassStats)
                .WithRequired(e => e.CharacterClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacterClass>()
                .HasMany(e => e.PlayerCharacters)
                .WithRequired(e => e.CharacterClass)
                .HasForeignKey(e => e.ActiveClassID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacterClass>()
                .HasMany(e => e.PCClasses)
                .WithRequired(e => e.CharacterClass)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassLevel>()
                .HasMany(e => e.ClassFeatLevels)
                .WithRequired(e => e.ClassLevel)
                .HasForeignKey(e => e.ClassLevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassLevel>()
                .HasMany(e => e.ClassFeatLevels1)
                .WithRequired(e => e.ClassLevel1)
                .HasForeignKey(e => e.ClassLevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassLevel>()
                .HasMany(e => e.ClassFeatLevels2)
                .WithRequired(e => e.ClassLevel2)
                .HasForeignKey(e => e.ClassLevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassLevel>()
                .HasMany(e => e.ClassStats)
                .WithRequired(e => e.ClassLevel)
                .HasForeignKey(e => e.LevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassLevel>()
                .HasMany(e => e.NPCs)
                .WithRequired(e => e.ClassLevel)
                .HasForeignKey(e => e.LevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassLevel>()
                .HasMany(e => e.PCClasses)
                .WithRequired(e => e.ClassLevel)
                .HasForeignKey(e => e.LevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CraftBlueprintCategory>()
                .HasMany(e => e.CraftBlueprints)
                .WithRequired(e => e.CraftBlueprintCategory)
                .HasForeignKey(e => e.CraftCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CraftBlueprint>()
                .HasMany(e => e.PCBlueprints)
                .WithRequired(e => e.CraftBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Craft>()
                .HasMany(e => e.CraftBlueprints)
                .WithRequired(e => e.Craft)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Craft>()
                .HasMany(e => e.CraftLevels)
                .WithRequired(e => e.Craft)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Craft>()
                .HasMany(e => e.PCCrafts)
                .WithRequired(e => e.Craft)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FactionRelationshipType>()
                .HasMany(e => e.FactionRelationships)
                .WithRequired(e => e.FactionRelationshipType)
                .HasForeignKey(e => e.RelationshipTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faction>()
                .HasMany(e => e.FactionRelationships)
                .WithRequired(e => e.Faction)
                .HasForeignKey(e => e.FactionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faction>()
                .HasMany(e => e.FactionRelationships1)
                .WithRequired(e => e.Faction1)
                .HasForeignKey(e => e.RelationshipTowardsFactionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faction>()
                .HasMany(e => e.PCFactionReputations)
                .WithRequired(e => e.Faction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyItemCategory>()
                .HasMany(e => e.KeyItems)
                .WithRequired(e => e.KeyItemCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyItem>()
                .HasMany(e => e.PCKeyItems)
                .WithRequired(e => e.KeyItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCKeyItem>()
                .Property(e => e.AcquiredDate)
                .HasPrecision(0);

            modelBuilder.Entity<PCTerritoryFlagsStructure>()
                .Property(e => e.CreateDate)
                .HasPrecision(0);

            modelBuilder.Entity<PCTerritoryFlagsStructure>()
                .HasMany(e => e.PCTerritoryFlagsStructuresItems)
                .WithRequired(e => e.PCTerritoryFlagsStructure)
                .HasForeignKey(e => e.PCStructureID);

            modelBuilder.Entity<PlayerCharacter>()
                .Property(e => e.CreateTimestamp)
                .HasPrecision(0);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCBlueprints)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCClasses)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCCrafts)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCFactionReputations)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCKeyItems)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasOptional(e => e.PCOutfit)
                .WithRequired(e => e.PlayerCharacter);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCOverflowItems)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasOptional(e => e.PCSystemVersion)
                .WithRequired(e => e.PlayerCharacter);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCTerritoryFlags)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCTerritoryFlagsPermissions)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Portrait>()
                .Property(e => e.Resref)
                .IsUnicode(false);

            modelBuilder.Entity<PWData>()
                .Property(e => e.player)
                .IsUnicode(false);

            modelBuilder.Entity<PWData>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<PWData>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PWData>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<PWObjData>()
                .Property(e => e.player)
                .IsUnicode(false);

            modelBuilder.Entity<PWObjData>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<PWObjData>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.ConstructionSites)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.PCTerritoryFlags)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.PCTerritoryFlagsStructures)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureCategory>()
                .HasMany(e => e.StructureBlueprints)
                .WithRequired(e => e.StructureCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TerritoryFlagPermission>()
                .HasMany(e => e.PCTerritoryFlagsPermissions)
                .WithRequired(e => e.TerritoryFlagPermission)
                .WillCascadeOnDelete(false);
        }
    }
}
