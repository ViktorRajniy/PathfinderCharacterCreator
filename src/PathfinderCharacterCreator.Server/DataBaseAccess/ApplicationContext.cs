namespace DataBaseAccess
{
    using DataBaseAccess.CoreBook.Equipment;
    using DataBaseAccess.CoreBook.General;
    using DataBaseAccess.CoreBook.Traits;
    using DataBaseAccess.CoreBook.Types;
    using Microsoft.EntityFrameworkCore;
    using static System.Net.Mime.MediaTypeNames;

    public class ApplicationContext : DbContext
    {
        #region DbSet

        public DbSet<DBItem> Items { get; set; } = null!;
        public DbSet<DBWeapon> Weapons { get; set; } = null!;
        public DbSet<DBArmor> Armors { get; set; } = null!;

        #endregion

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        /// <summary>
        /// Метод заполняющий начальные поля базы данных.
        /// </summary>
        /// <param name = "modelBuilder" ></ param >
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Armor

            modelBuilder.Entity<DBArmor>().HasData(
                new DBArmor()
                {
                    Name = "Explorer's Clothing",
                    Cost = 10,
                    Weight = 0.1,
                    ArmorBonus = 0,
                    DexterityCapacity = 5,
                    CheckPenalty = 0,
                    SpeedPenalty = 0,
                    Strength = 0,
                    Group = ArmorGroup.Cloth,
                    Traits = new List<ArmorTraits> { ArmorTraits.Comfort },
                    Type = ArmorType.Unarmored,
                },
                new DBArmor()
                {
                    Name = "Padded Armor",
                    Cost = 20,
                    Weight = 0.1,
                    ArmorBonus = 1,
                    DexterityCapacity = 3,
                    CheckPenalty = 0,
                    SpeedPenalty = 0,
                    Strength = 10,
                    Group = ArmorGroup.Cloth,
                    Traits = new List<ArmorTraits> { ArmorTraits.Comfort },
                    Type = ArmorType.Light,
                },
                new DBArmor()
                {
                    Name = "Leather",
                    Cost = 200,
                    Weight = 1,
                    ArmorBonus = 1,
                    DexterityCapacity = 4,
                    CheckPenalty = 1,
                    SpeedPenalty = 0,
                    Strength = 10,
                    Group = ArmorGroup.Leather,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Light,
                },
                new DBArmor()
                {
                    Name = "Studded Leather",
                    Cost = 300,
                    Weight = 1,
                    ArmorBonus = 2,
                    DexterityCapacity = 3,
                    CheckPenalty = 1,
                    SpeedPenalty = 0,
                    Strength = 12,
                    Group = ArmorGroup.Leather,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Light,
                },
                new DBArmor()
                {
                    Name = "Chain Shirt",
                    Cost = 500,
                    Weight = 1,
                    ArmorBonus = 2,
                    DexterityCapacity = 3,
                    CheckPenalty = 1,
                    SpeedPenalty = 0,
                    Strength = 12,
                    Group = ArmorGroup.Chain,
                    Traits = new List<ArmorTraits>
                    {
                        ArmorTraits.Noisy,
                        ArmorTraits.Flexible
                    },
                    Type = ArmorType.Light,
                },
                new DBArmor()
                {
                    Name = "Hide",
                    Cost = 200,
                    Weight = 2,
                    ArmorBonus = 3,
                    DexterityCapacity = 2,
                    CheckPenalty = 2,
                    SpeedPenalty = 5,
                    Strength = 14,
                    Group = ArmorGroup.Leather,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Medium,
                },
                new DBArmor()
                {
                    Name = "Scale Mail",
                    Cost = 400,
                    Weight = 2,
                    ArmorBonus = 3,
                    DexterityCapacity = 2,
                    CheckPenalty = 2,
                    SpeedPenalty = 5,
                    Strength = 14,
                    Group = ArmorGroup.Composite,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Medium,
                },
                new DBArmor()
                {
                    Name = "Chain Mail",
                    Cost = 600,
                    Weight = 2,
                    ArmorBonus = 4,
                    DexterityCapacity = 1,
                    CheckPenalty = 2,
                    SpeedPenalty = 5,
                    Strength = 16,
                    Group = ArmorGroup.Chain,
                    Traits = new List<ArmorTraits>
                    {
                        ArmorTraits.Noisy,
                        ArmorTraits.Flexible
                    },
                    Type = ArmorType.Medium,
                },
                new DBArmor()
                {
                    Name = "Breastplate",
                    Cost = 800,
                    Weight = 2,
                    ArmorBonus = 4,
                    DexterityCapacity = 1,
                    CheckPenalty = 2,
                    SpeedPenalty = 5,
                    Strength = 16,
                    Group = ArmorGroup.Plate,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Medium,
                },
                new DBArmor()
                {
                    Name = "Splint mail",
                    Cost = 1300,
                    Weight = 3,
                    ArmorBonus = 5,
                    DexterityCapacity = 1,
                    CheckPenalty = 3,
                    SpeedPenalty = 10,
                    Strength = 16,
                    Group = ArmorGroup.Composite,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Heavy,
                },
                new DBArmor()
                {
                    Name = "Half plate",
                    Cost = 1800,
                    Weight = 3,
                    ArmorBonus = 5,
                    DexterityCapacity = 1,
                    CheckPenalty = 3,
                    SpeedPenalty = 10,
                    Strength = 16,
                    Group = ArmorGroup.Plate,
                    Traits = new List<ArmorTraits> { },
                    Type = ArmorType.Heavy,
                },
                new DBArmor()
                {
                    Name = "Full Plate",
                    Cost = 3000,
                    Weight = 4,
                    ArmorBonus = 6,
                    DexterityCapacity = 0,
                    CheckPenalty = 3,
                    SpeedPenalty = 10,
                    Strength = 18,
                    Group = ArmorGroup.Plate,
                    Traits = new List<ArmorTraits> { ArmorTraits.Bulwark },
                    Type = ArmorType.Heavy
                },
                new DBArmor()
                {
                    Name = "Hellknight Plate",
                    Cost = 3500,
                    Weight = 4,
                    ArmorBonus = 6,
                    DexterityCapacity = 0,
                    CheckPenalty = 3,
                    SpeedPenalty = 10,
                    Strength = 18,
                    Group = ArmorGroup.Plate,
                    Traits = new List<ArmorTraits> { ArmorTraits.Bulwark },
                    Type = ArmorType.Heavy
                }
                );

            #endregion

            #region Weapons

            modelBuilder.Entity<DBWeapon>().HasData(
                new DBWeapon()
                {
                    Name = "Jaws",
                    Cost = 0,
                    Weight = 0,
                    DamageDices = new List<string> { "1d6" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Brawling,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Finesse,
                        WeaponTraits.Unarmed,
                    },
                    Type = WeaponType.Unarmed
                },
                new DBWeapon()
                {
                    Name = "Club",
                    Cost = 0,
                    Weight = 1,
                    DamageDices = new List<string> { "1d6" },
                    DamageTypes = new List<DamageType> { DamageType.Bludgeoning },
                    Group = WeaponGroup.Club,
                    Traits = new List<WeaponTraits> { WeaponTraits.Thrown },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Dagger",
                    Cost = 20,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Knife,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Thrown,
                        WeaponTraits.Agile,
                        WeaponTraits.Finesse,
                        WeaponTraits.Versatile,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Light Mace",
                    Cost = 40,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Bludgeoning },
                    Group = WeaponGroup.Club,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Agile,
                        WeaponTraits.Finesse,
                        WeaponTraits.Shove,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Mace",
                    Cost = 100,
                    Weight = 1,
                    DamageDices = new List<string> { "1d6" },
                    DamageTypes = new List<DamageType> { DamageType.Bludgeoning },
                    Group = WeaponGroup.Club,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Shove,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Morningstar",
                    Cost = 100,
                    Weight = 1,
                    DamageDices = new List<string> { "1d6" },
                    DamageTypes = new List<DamageType> { DamageType.Bludgeoning },
                    Group = WeaponGroup.Club,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Versatile,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Sickle",
                    Cost = 20,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Slashing },
                    Group = WeaponGroup.Knife,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Agile,
                        WeaponTraits.Finesse,
                        WeaponTraits.Trip,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Staff",
                    Cost = 0,
                    Weight = 1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Bludgeoning },
                    Group = WeaponGroup.Club,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.TwoHand
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Spear",
                    Cost = 10,
                    Weight = 1,
                    DamageDices = new List<string> { "1d6" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Spear,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Thrown
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Longspear",
                    Cost = 50,
                    Weight = 2,
                    DamageDices = new List<string> { "1d8" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Spear,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Reach
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Gauntlet",
                    Cost = 20,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Bludgeoning },
                    Group = WeaponGroup.Brawling,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Agile,
                        WeaponTraits.FreeHand
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Spiked Gauntlet",
                    Cost = 30,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Brawling,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Agile,
                        WeaponTraits.FreeHand
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Clan Dagger",
                    Cost = 200,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Knife,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Agile,
                        WeaponTraits.Parry,
                        WeaponTraits.Dwarf,
                        WeaponTraits.Versatile,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Katar",
                    Cost = 30,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d4" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Group = WeaponGroup.Knife,
                    Traits = new List<WeaponTraits>
                    {
                        WeaponTraits.Agile,
                        WeaponTraits.Deadly,
                        WeaponTraits.Monk,
                    },
                    Type = WeaponType.Simple
                },
                new DBWeapon()
                {
                    Name = "Javelin",
                    Cost = 10,
                    Weight = 0.1,
                    DamageDices = new List<string> { "1d6" },
                    DamageTypes = new List<DamageType> { DamageType.Piercing },
                    Type = WeaponType.Simple,
                    Group = WeaponGroup.Dart,
                    Traits = new List<WeaponTraits>()
                    {
                        WeaponTraits.Thrown
                    }
                }
                );

            #endregion

            modelBuilder.Entity<DBItem>().HasData(

            #region DBItem

            new DBItem()
            {
                Name = "Adventurer's Pack",
                Cost = 15,
                Weight = 1
            },
            new DBItem()
            {
                Name = "Alchemist's Tools",
                Cost = 300,
                Weight = 1
            },
            new DBItem()
            {
                Name = "Basic Crafter's Book",
                Cost = 10,
                Weight = 1
            },
            new DBItem()
            {
                Name = "Caltrops",
                Cost = 30,
                Weight = 0.1
            },
            new DBItem()
            {
                Name = "Grappling hook",
                Cost = 10,
                Weight = 0.1
            },
            new DBItem()
            {
                Name = "Material component pouch",
                Cost = 50,
                Weight = 0.1
            },
            new DBItem()
            {
                Name = "Writting set",
                Cost = 100,
                Weight = 0.1
            }

            );

            #endregion

            #region DBSeveralItems

            modelBuilder.Entity<DBSeveralItems>().HasData(
                new DBSeveralItems()
                {
                    Name = "Sling bullets",
                    Count = 20,
                    SeveralCount = 10,
                    SeveralElementWeight = 0.1,
                    SeveralElementCost = 1,
                }
             );

            #endregion
        }
    }
}
