﻿namespace DataBaseAccess
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Abilities;
    using DataBaseAccess.CoreBook.Actions;
    using DataBaseAccess.CoreBook.Equipment;
    using DataBaseAccess.CoreBook.Feats;
    using DataBaseAccess.CoreBook.General;
    using DataBaseAccess.CoreBook.Skills;
    using DataBaseAccess.CoreBook.Traits;
    using DataBaseAccess.CoreBook.Types;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        #region DbSet
        public DbSet<DBAncestry> Ancestries { get; set; } = null!;
        public DbSet<DBHaritage> Haritages { get; set; } = null!;
        public DbSet<DBClass> Class { get; set; } = null!;
        public DbSet<DBSubClass> Subclasses { get; set; } = null!;
        public DbSet<DBBackground> Backgrounds { get; set; } = null!;
        public DbSet<DBDeity> Deities { get; set; } = null!;
        public DbSet<DBSkill> Skills { get; set; } = null!;
        public DbSet<DBAbility> Abilities { get; set; } = null!;
        public DbSet<DBFeat> Feats { get; set; } = null!;
        public DbSet<DBAction> Actions { get; set; } = null!;
        public DbSet<DBItem> Items { get; set; } = null!;
        public DbSet<DBWeapon> Weapons { get; set; } = null!;
        public DbSet<DBArmor> Armors { get; set; } = null!;
        public DbSet<DBCharacter> Characters { get; set; } = null!;
        public DbSet<DBCreationInfo> CreationInfos { get; set; } = null!;
        public DbSet<DBGeneralInfo> GeneralInfos { get; set; } = null!;
        public DbSet<DBStats> Stats { get; set; } = null!;
        public DbSet<DBUser> Users { get; set; } = null!;

        #endregion

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        /// <summary>
        /// Метод заполняющий начальные поля базы данных.
        /// </summary>
        /// <param name = "modelBuilder" ></ param >
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBUser>().HasData(
            new DBUser
            {
                ID = 1,
                Email = "email",
                Password = "password",
                CharacterList = new List<DBCharacter> {}
            });

            #region DBEquipment

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

            #region DBItem

            modelBuilder.Entity<DBItem>().HasData(

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

            #endregion

            #region Abilities

            modelBuilder.Entity<DBAbility>().HasData(
                new DBAbility
                {
                    ID = AbilityType.Strength,
                    Name = "Сила",
                    Description = "Сила измеряет физическую силу вашего персонажа. " +
                    "Она важна если персонаж собирается драться в ближнем бою. Ваш " +
                    "модификатор Силы добавляется к броскам урона ближнего боя, и " +
                    "определяет сколько веса может переносить персонаж."
                },
                new DBAbility
                {
                    ID = AbilityType.Dexterity,
                    Name = "Ловкость",
                    Description = "Ловкость показывает проворность, чувство равновесия " +
                    "и рефлексы вашего персонажа. Она важна если персонаж собирается " +
                    "использовать дистанционные атаки, или скрытность, чтобы удивлять " +
                    "врагов. Еще ваш модификатор Ловкости добавляется к КБ и спасброскам " +
                    "Рефлекса."
                },
                new DBAbility
                {
                    ID = AbilityType.Constitution,
                    Name = "Телосложение",
                    Description = "Телосложение показывает общую выносливость и здоровье " +
                    "персонажа. Она важна для всех персонажей, особенно для тех, кто " +
                    "дерется в ближнем бою. Ваш модификатор Телосложения добавляется к " +
                    "Очкам Здоровья и спасброскам Стойкости."
                },
                new DBAbility
                {
                    ID = AbilityType.Intelligence,
                    Name = "Интеллект",
                    Description = "Интеллект измеряет как хорошо ваш персонаж учится и " +
                    "соображает. Высокий Интеллект позволяет вашему персонажу анализировать " +
                    "ситуации и понимать шаблоны, и это значит, что он может обучиться " +
                    "дополнительным навыкам и выучить дополнительные языки."
                },
                new DBAbility
                {
                    ID = AbilityType.Wisdom,
                    Name = "Мудрость",
                    Description = "Мудрость измеряет основные чувства, внимательность и " +
                    "интуицию персонажа. Ваш модификатор Мудрости добавляется к " +
                    "Восприятию и спасброскам Воли."
                },
                new DBAbility
                {
                    ID = AbilityType.Charisma,
                    Name = "Харизма",
                    Description = "Харизма отражает притягательность и силу личности " +
                    "персонажа. Высокая Харизма помогает влиять на других и вдохновлять их."
                }
                );

            #endregion

            #region Skills

            modelBuilder.Entity<DBSkill>().HasData(
                new DBSkill
                {
                    ID = SkillType.Acrobatics,
                    Name = "Акробатика",
                    Description = "Акробатика измеряет вашу способность выполнять задачи, " +
                    "требующие координации и изящества. При использовании основного действия " +
                    "Вырваться, вы можете использовать свой модификатор Акробатики, вместо " +
                    "вашего модификатора безоружной атаки.",
                },
                new DBSkill
                {
                    ID = SkillType.Arcana,
                    Name = "Аркана",
                    Description = "Аркана измеряет как много вы знаете об арканной магии и " +
                    "существах. Даже если вы нетренированы, то можете Вспомнить информацию.",
                },
                new DBSkill
                {
                    ID = SkillType.Athletics,
                    Name = "Атлетика",
                    Description = "Атлетика позволяет совершать действия связанные с физической " +
                    "подготовкой. Когда вы используете простое действие Вырваться, то можете " +
                    "использовать свой модификатор Атлетики вместо модификатора безоружной атаки.",
                },
                new DBSkill
                {
                    ID = SkillType.Crafting,
                    Name = "Ремесло",
                    Description = "Вы можете использовать этот навык, чтобы создавать и " +
                    "ремонтировать предметы. Даже если вы нетренированы, вы можете использовать " +
                    "Вспомнить информацию.",
                },
                new DBSkill
                {
                    ID = SkillType.Deception,
                    Name = "Обман",
                    Description = "Вы можете обманывать и вводить в заблуждение других, " +
                    "используя маскировку, ложь и другие виды уловок.",
                },
                new DBSkill
                {
                    ID = SkillType.Diplomacy,
                    Name = "Дипломатия",
                    Description = "Вы влияете на других с помощью переговоров и лести.",
                },
                new DBSkill
                {
                    ID = SkillType.Intimidation,
                    Name = "Запугивание",
                    Description = "Вы угрозами подчиняете других своей воле.",
                },
                new DBSkill
                {
                    ID = SkillType.Medicine,
                    Name = "Медицина",
                    Description = "Вы можете залатать раны и помочь людям оправиться от " +
                    "болезней и ядов. Даже если вы нетренированы Медицине, то можете " +
                    "Вспомнить информацию.",
                },
                new DBSkill
                {
                    ID = SkillType.Nature,
                    Name = "Природа",
                    Description = "Вы много знаете о природе, командуете и тренируете " +
                    "животных и магических чудовищ. Даже если вы нетренированы Природе, " +
                    "то можете Вспомнить информацию.",
                },
                new DBSkill
                {
                    ID = SkillType.Occultism,
                    Name = "Оккультизм",
                    Description = "Вы много знаете о древних философиях, эзотерических " +
                    "знаниях, неясном мистицизме, и сверхъестественных существах. Даже если" +
                    " вы нетренированы Оккультизму, то можете Вспомнить информацию.",
                },
                new DBSkill
                {
                    ID = SkillType.Performance,
                    Name = "Выступление",
                    Description = "Вы искусны в разных видах выступлений, используя свои " +
                    "таланты, чтобы впечатлять толпу или заработать на жизнь.",
                },
                new DBSkill
                {
                    ID = SkillType.Religion,
                    Name = "Религия",
                    Description = "Для вас открыты тайны божеств, догмы, верования и царства " +
                    "божественных созданий, как величественных, так и зловещих. Еще вы " +
                    "понимаете как работает магия, хотя ваше обучение придает этому знанию " +
                    "религиозный уклон. Даже если вы нетренированы Религии, то можете " +
                    "Вспомнить информацию.",
                },
                new DBSkill
                {
                    ID = SkillType.Society,
                    Name = "Общество",
                    Description = "Вы понимаете людей и принципы, которые управляют " +
                    "цивилизацией, и вы знаете исторические события, которые делают общества " +
                    "такими, какими они являются сегодня. Кроме того, вы можете использовать " +
                    "эти знания для управления сложной физической, социальной и экономической " +
                    "работой поселений. Даже если вы нетренированы навыку Общества, то можете " +
                    "использовать следующие общие действия навыка: Вспомнить информацию о " +
                    "местной истории, важных личностях, правовых институтах, социальной " +
                    "структуре и гуманоидных культурах. Мастер может разрешить использовать " +
                    "Общество на других существ, которые являются столпами общества в этом " +
                    "регионе, таким как драконья знать управляющая королевством людей. " +
                    "Проживание в поселениях, ища место для жилья, занимаясь попрошайничеством" +
                    " или выпрашивая еду.",
                },
                new DBSkill
                {
                    ID = SkillType.Stealth,
                    Name = "Скрытность",
                    Description = "Вы умеете избегать обнаружения, что позволяет вам " +
                    "проскальзывать мимо врагов, прятаться или скрывать предмет.",
                },
                new DBSkill
                {
                    ID = SkillType.Survival,
                    Name = "Выживание",
                    Description = "Вы знаток выживания в глуши, добывания пищи и строительства " +
                    "убежища, а с тренировкой вы открываете секреты выслеживания и заметания " +
                    "своих следов. Даже если вы нетренированы, то можете использовать " +
                    "Выживание для Проживания.",
                },
                new DBSkill
                {
                    ID = SkillType.Thievery,
                    Name = "Воровство",
                    Description = "Вы обучены определенному набору навыков, которые " +
                    "предпочитают воры и негодяи.",
                },
                new DBSkill
                {
                    ID = SkillType.Lore,
                    Name = "Знание",
                    Description = "У вас есть особая информация по специфичной теме. " +
                    "Знания имеют много подразделов. У вас могу быть Военные, Мореходные, " +
                    "Знания о вампирах, или любые другие подразделы этого навыка. Каждый " +
                    "подраздел Знаний считается отдельным навыком, так что увеличение навыка " +
                    "Знаний о Планах, не увеличивает ваш уровень мастерства Мореходных Знаний.",
                }
                );

            #endregion

            #region DBGeneralInfo

            #region Classes

            modelBuilder.Entity<DBClass>().HasData(
                new DBClass
                {
                    ID = ClassType.Fighter,
                    ClassName = "Воин",
                    Description = "Сражаясь ради чести, жадности, верности или просто ради " +
                    "азарта битвы, вы бесспорно являетесь мастером владения оружием и боевыми " +
                    "техниками. Вы сочетаете свои действия в комбинациях открывающих движений," +
                    " завершающих ударов, и контратак, когда ваши враги по неосторожности " +
                    "ослабят защиту. Являетесь ли вы рыцарем, наемником, снайпером или " +
                    "мастером клинка, вы искусно отточили свои боевые навыки и обрушиваете " +
                    "сокрушительные критические атаки на своих врагов.",
                    YouCanDescription = "Знать назначение и качество каждого оружия и части " +
                    "доспеха, которыми владеете. Признавать, что опасность жизни авантюриста " +
                    "должна быть уравновешена отличной попойкой или амбициозными делами. Быть " +
                    "нетерпеливым при решении головоломок или проблем, требующих обстоятельной " +
                    "логики или обучения.",
                    OtherMaybeDescription = "Считать вас пугающим, пока не узнают вас поближе, " +
                    "а возможно, и даже после того, как узнают. Ожидать, что вы лишь грубая " +
                    "сила без мозгов. Уважать ваш опыт в военном искусстве и ценят ваше мнение " +
                    "о качестве вооружения.",
                    HealthPoints = 10,
                    Perception = ProficientyType.Expert,
                    Fortitude = ProficientyType.Expert,
                    Reflex = ProficientyType.Expert,
                    Will = ProficientyType.Trained,
                    SkillsCount = 3,
                },
                new DBClass
                {
                    ID = ClassType.Alchemist,
                    ClassName = "Алхимик",
                    Description = "Для вас нет более прекрасного зрелища, чем странное варево, " +
                    "бурлящее в мензурке, и вы с самозабвением поглощаете свои гениальные " +
                    "эликсиры. Вы очарованы раскрытием тайн науки и природы, и постоянно, в " +
                    "своей лаборатории или прямо на ходу, экспериментируете с изобретательными " +
                    "составами на все случаи жизни. Вы бесстрашны в рисковой ситуации, бросая " +
                    "в своих врагов взрывчатые и токсичные склянки. Ваш уникальный путь к " +
                    "величию проложен алхимическими отварами, которые доводят ваш ум и тело " +
                    "до предела.",
                    YouCanDescription = "Наслаждаться возней со странными формулами и " +
                    "алхимическими реагентами, часто с безрассудством и целеустремленной " +
                    "самоотдачей, которые заставляют других задуматься. Получать " +
                    "удовольствие от того, чтобы сеять хаос с помощью сделанных вами " +
                    "алхимических смесей, и наслаждаться тем, как вещи горят, растворяются, " +
                    "замерзают и сотрясаются. Бесконечно экспериментировать, чтобы " +
                    "обнаружить новые, более мощные алхимические инструменты.",
                    OtherMaybeDescription = "Думают, что вы какой-то чародей или эксцентричный " +
                    "волшебник, и не понимают, что вы не сотворяете заклинаний; заклинатели, " +
                    "которые топорно балуются алхимией, только усиливают это заблуждение. " +
                    "Не понимают ваше рвение к алхимии, креативности и изобретательству. " +
                    "Предполагают, что если вы не вызвали катастрофу своими экспериментами, " +
                    "то неизбежно сделаете это позже",
                    HealthPoints = 8,
                    Perception = ProficientyType.Trained,
                    Fortitude = ProficientyType.Expert,
                    Reflex = ProficientyType.Expert,
                    Will = ProficientyType.Trained,
                    SkillsCount = 3,
                    ClassSkill = SkillType.Crafting,
                },
                new DBClass
                {
                    ID = ClassType.Wizzard,
                    ClassName = "Волшебник",
                    Description = "Вы вечный ученик арканных тайн вселенной, использующий свое " +
                    "мастерство магии для создания мощных и разрушительных заклинаний. Вы " +
                    "относитесь к магии как к науке, сопоставляя новейшие тексты по " +
                    "практическому колдовству с древними эзотерическими фолиантами, " +
                    "чтобы разузнать и понять, как работает магия. Тем не менее, магическая " +
                    "теория обширна, и вы не можете изучить ее всю. Вы либо специализируетесь " +
                    "на одной из восьми школ магии, приобретая более глубокое понимание нюансов " +
                    "этих заклинаний, либо предпочитаете более широкий подход, который " +
                    "подчеркивает, как глубоко переплетена вся магия.",
                    YouCanDescription = "Испытывать неутолимое интеллектуальное любопытство по " +
                    "поводу того, как все устроено в мире вокруг вас, в частности, магия. " +
                    "Искренне верить, что ваша школа магии наилучшая (если вы специалист) " +
                    "или что истинное мастерство магии требует знания всех школ (если вы " +
                    "универсалист). Использовать эзотерический жаргон и технические термины, " +
                    "чтобы точно описать мельчайшие детали магических эффектов, даже если " +
                    "разница, вероятно, неуловима для других людей.",
                    OtherMaybeDescription = "Считают вас невероятно могущественным и " +
                    "потенциально опасным. Боятся того, что ваша магия может сделать с их " +
                    "умами, телами и душами, и просят вас избегать произнесения заклинаний в " +
                    "нормальной компании, поскольку мало кто может определить, является ли одно " +
                    "из ваших заклинаний безвредным или злонамеренным, пока не станет слишком " +
                    "поздно. Полагают, что вы можете легко решить все их проблемы, от ненастной " +
                    "погоды до плохой урожайности, и просят вас о заклинаниях, которые могут " +
                    "помочь им получить все, что они пожелают.",
                    HealthPoints = 6,
                    Perception = ProficientyType.Trained,
                    Fortitude = ProficientyType.Trained,
                    Reflex = ProficientyType.Trained,
                    Will = ProficientyType.Expert,
                    SkillsCount = 2,
                    ClassSkill = SkillType.Arcana,
                },
                new DBClass
                {
                    ID = ClassType.Champion,
                    ClassName = "Чемпион",
                    Description = "Вы - посланник божества, преданный служитель, взявший на " +
                    "себя тяжелую ношу, и придерживающийся кодекса, который отличает вас от " +
                    "окружающих. В то время как чемпионы существуют для всех мировоззрений, " +
                    "как чемпион добра, вы даете уверенность и надежду невинным. У вас есть " +
                    "мощная защита, которой вы делитесь со своими союзниками и невинными " +
                    "очевидцами, а также святая сила, которую вы используете, чтобы положить " +
                    "конец угрозе зла. Ваша преданность даже привлекает внимание святых духов, " +
                    "которые помогают вам в путешествии.",
                    YouCanDescription = "Верить, что всегда есть надежда, что добро " +
                    "восторжествует над злом, независимо от того, насколько мрачны шансы. " +
                    "Знать, что цель не оправдывает средства, поскольку злые деяния лишь " +
                    "увеличивают влияние зла. Иметь сильное чувство правильного и " +
                    "неправильного, и можете отчаяться, когда жадность или недальновидность " +
                    "порождают зло.",
                    OtherMaybeDescription = "Видят в вас символ надежды, особенно в период " +
                    "великой нужды. Беспокоятся, что вы втайне презираете их за то, что они не " +
                    "соответствуют вашим запредельным стандартам, или что вы непреклонны по " +
                    "отношению к компромиссам, когда это необходимо. Знают, что вы дали " +
                    "сакральные клятвы служения, и верят, что вы сдержите их",
                    HealthPoints = 10,
                    Perception = ProficientyType.Trained,
                    Fortitude = ProficientyType.Expert,
                    Reflex = ProficientyType.Trained,
                    Will = ProficientyType.Expert,
                    SkillsCount = 2,
                    ClassSkill = SkillType.Religion,
                });

            #endregion

            #region SubClasses

            modelBuilder.Entity<DBSubClass>().HasData(
                new DBSubClass
                {
                    ID = SubClassType.PaladinChampion,
                    Name = "Паладин",
                    Description = "Вы честны, прямолинейны и преданы идее давать отпор " +
                    "жестокости. Вы получаете реакцию чемпиона Карающий удар и заклинание " +
                    "преданности Наложение рук. После догмат добра, добавляются следующие:" +
                    " Вы должны действовать с честью, никогда не пользуясь преимуществом над " +
                    "другими, не лгать и не обманывать. Вы должны уважать легальную власть " +
                    "законного правителя, куда бы вы ни пошли, и следовать его законам.",
                    ClassID = ClassType.Champion,
                },
                new DBSubClass
                {
                    ID = SubClassType.RedeemerChampion,
                    Name = "Искупитель",
                    Description = "Вы полны добра и прощения. Вы получаете реакцию чемпиона " +
                    "Проблеск искупления и заклинание преданности Наложение рук. После догмат " +
                    "добра, добавляются следующие: Вы должны сначала попытаться искупить тех, " +
                    "кто совершает злые поступки, а не убивать их или назначать наказание. " +
                    "Если они затем продолжат идти по пути зла, возможно, вам придется принять " +
                    "более крайние меры. Вы должны проявлять сострадание к другим, независимо от " +
                    "их авторитета или положения.",
                    ClassID = ClassType.Champion,
                },
                new DBSubClass
                {
                    ID = SubClassType.LiberatorChampion,
                    Name = "Освободитель",
                    Description = "Вы обязаны защищать свободу других. Вы получаете реакцию " +
                    "чемпиона Освобождающий шаг и заклинание преданности Наложение рук. После " +
                    "догмат добра, добавляются следующие: Вы должны уважать выборы, которые " +
                    "другие совершают в своей собственной жизни, и вы не можете принуждать " +
                    "кого-то действовать определенным образом или угрожать им, если они этого " +
                    "не делают. Вы должны требовать свободы других и бороться за их " +
                    "возможность принимать свои собственные решения. Вы никогда не должны быть " +
                    "вовлечены в работорговлю или тиранию, или поддерживать их.",
                    ClassID = ClassType.Champion,
                },
                new DBSubClass
                {
                    ID = SubClassType.Fighter,
                    Name = "Воин",
                    Description = "Воин не имеет подклассов.",
                    ClassID = ClassType.Fighter,
                },
                new DBSubClass
                {
                    ID = SubClassType.BomberAlchemist,
                    Name = "Бомбометатель",
                    Description = "Вы специализируетесь на взрывах и других неистовых " +
                    "алхимических реакциях. В дополнение к вашим другим формулам, вы " +
                    "начинаете с формулами 2 алхимических бомб 1-го уровня в книге формул. " +
                    "Когда вы метаете алхимическую бомбу с признаком брызги, то можете нанести " +
                    "урон брызгами только вашей основной цели, а не по обычной области брызг.",
                    ClassID = ClassType.Alchemist,
                },
                new DBSubClass
                {
                    ID = SubClassType.ChirurgeonAlchemist,
                    Name = "Хирург",
                    Description = "Вы сосредоточены на исцелении других при помощи алхимии. " +
                    "В дополнение к вашим другим формулам, вы начинаете с формулами 2 обычных " +
                    "алхимических эликсиров 1-го уровня с признаком исцеление " +
                    "(таких как Эликсир жизни, слабый, Противоядие, малое, Лекарство, малое). " +
                    "Вы можете использовать свое мастерство Ремесла для всего, что требует " +
                    "мастерство Медицины (например, предварительные условия способностей) и " +
                    "для всех проверок Медицины использовать свой модификатор Ремесла вместо " +
                    "модификатора Медицины.",
                    ClassID = ClassType.Alchemist,
                },
                new DBSubClass
                {
                    ID = SubClassType.MutagenistAlchemist,
                    Name = "Мутагенист",
                    Description = "Вы фокусируетесь на причудливых мутагенных трансформациях, " +
                    "которые жертвуют одним аспектом физической или психологической сути " +
                    "существа, ради усиления другого. В дополнение к вашим другим формулам, " +
                    "вы начинаете с формулами 2 мутагенов 1-го уровня в книге формул.",
                    ClassID = ClassType.Alchemist,
                },
                new DBSubClass
                {
                    ID = SubClassType.StaffNexusWizzard,
                    Name = "Узы посоха",
                    Description = "Ваша диссертация утверждает, что раннее и интенсивное " +
                    "использование посохов, с первых дней обучения может создать симбиотическую " +
                    "связь между заклинателем и посохом, позволяя им вместе создавать " +
                    "замечательную магию. Вы образовали такую связь с созданными вами " +
                    "импровизированным посохом, и готовы наполнить большей силой любой посох, " +
                    "с которым вы сталкиваетесь. Вы начинаете игру с импровизированным " +
                    "посохом собственной разработки. Он содержит 1 чары и 1 заклинание 1-го " +
                    "уровня, оба из вашей книги заклинаний, но он не получает заряды как обычно " +
                    "во время ваших ежедневных приготовлений; вы должны потратить слот " +
                    "заклинания, чтобы дать ему заряды таким же образом, как вы бы добавили " +
                    "дополнительные заряды в обычный посох. Вы можете Создать свой " +
                    "импровизированный посох в любой другой вид посоха, за обычную стоимость " +
                    "нового посоха, добавляя к создаваемому новому посоху 2 заклинания, которые " +
                    "вы выбрали изначально. На 8-м уровне, при подготовке посоха, вы можете " +
                    "израсходовать 2 заклинания, вместо одного, добавляя дополнительные заряды, " +
                    "в количестве общего уровня израсходованных заклинаний. На 16-м уровне, " +
                    "вы можете израсходовать вплоть до 3 заклинаний, добавляя дополнительные " +
                    "заряды, в количестве общего уровня всех 3 заклинаний израсходованных при " +
                    "подготовке.",
                    ClassID = ClassType.Wizzard,
                },
                new DBSubClass
                {
                    ID = SubClassType.MetamagicalExperimentationWizzard,
                    Name = "Метамагическое экспериментирование",
                    Description = "Вы поняли, что практика, известная как метамагия, это " +
                    "отголосок давних времен, когда волшебники должны были разрабатывать свои " +
                    "собственные заклинания и их вариации, а не полагаться на заклинания, " +
                    "записанные другими и передаваемые на протяжении многих лет. Это позволяет " +
                    "вам рационально получать доступ к различным метамагическим эффектам. Вы " +
                    "получаете на свой выбор способность волшебника 1-го уровня с признаком " +
                    "метамагия. Начиная с 4-го уровня, во время ваших дневных приготовлений, " +
                    "вы можете получить метамагическую способность волшебника на свой выбор и " +
                    "использовать до следующих дневных приготовлений. Выбираемая метамагическая " +
                    "способность должна иметь уровень, не более половины вашего уровня.",
                    ClassID = ClassType.Wizzard,
                });

            #endregion

            #region Ancestries

            modelBuilder.Entity<DBAncestry>().HasData(
             new DBAncestry
             {
                 ID = AncestryType.Dwarf,
                 Name = "Дварф",
                 Description = "Дварфы не спешат доверять тем, кто не принадлежит к их роду, " +
                 "и эта осторожность не лишена оснований. У дварфов долгая история вынужденного " +
                 "изгнания из своих родовых владений и борьбы с набегами одичалых врагов, в " +
                 "особенности гигантов, гоблиноидов, орков и тех ужасов, которые обитают глубоко " +
                 "под поверхностью. В то время как доверие дварфа тяжело завоевать, однажды " +
                 "обретенное, оно крепко, как железо. Если вы хотите играть персонажем, " +
                 "который тверд как гвоздь, упрям и является неумолимым авантюристом, с " +
                 "примесью суровой твердости и глубокой мудрости, или, по крайней мере, " +
                 "упрямой убежденности, то вы должны играть дварфом.",
                 YouCanDescription = "Попытаться защитить свою честь, независимо от ситуации. " +
                 "Ценить качество работы ремесленника во всех его проявлениях и настаивать на " +
                 "нем для всего вашего снаряжения. Не колебаться и не отступать, как только вы " +
                 "решитесь на что-то",
                 OtherMaybeDescription = "Считают вас упрямым, однако независимо от того, видят " +
                 "ли они в этом пользу или вред, мнение меняется от человека к человеку. " +
                 "Предполагают, что вы являетесь экспертом в вопросах, связанных с каменной " +
                 "кладкой, добычей полезных ископаемых, драгоценных металлов и драгоценных " +
                 "камней. Понимают вашу глубокую связь со своей семьей, наследием и друзьями",
                 PhisicalDescription = "Дварфы невысокие и коренастые, ростом примерно на " +
                 "фут ниже большинства людей. У них широкие, плотные тела и крепкое " +
                 "телосложение. Дварфы всех полов гордятся длиной своих волос, которые они " +
                 "часто заплетают в замысловатые узоры, часть из которых представляют " +
                 "определенные кланы. Длинная борода - признак мужественности и чести среди " +
                 "дварфов, и поэтому гладко выбритый мужчина-дварф считается слабым, ненадежным " +
                 "или того хуже. Дварфы обычно достигают физической зрелости около 25 лет, " +
                 "хотя их традиционная культура придает большее значение завершению церемоний " +
                 "достижения совершеннолетия, уникальных для каждого клана, нежели достижению " +
                 "определенного возраста. Типичный дварф может дожить до 350 лет.",
                 HealthPoints = 10,
                 Speed = 20,
             },
             new DBAncestry
             {
                 ID = AncestryType.Goblin,
                 Name = "Гоблин",
                 Description = "Гоблины имеют репутацию простых существ, которые любят песни, " +
                 "огонь и поедать отвратительные вещи, и которые ненавидят чтение, собак и " +
                 "лошадей, и есть очень много тех, для кого это описание подходит идеально. " +
                 "Однако среди гоблинов произошли большие перемены, и все больше и больше " +
                 "сопротивляются этим стереотипам. Даже среди более мирских гоблинов, многие " +
                 "все еще служат примером своего старого образа жизни в некоторой небольшой " +
                 "степени. Некоторые гоблины по прежнему глубоко очарованны огнем или " +
                 "бесстрашно поглощают пищу, которая может вывернуть наизнанку желудки других. " +
                 "Другие - вечные изобретатели, и рассматривают мусор своих товарищей как " +
                 "компоненты гаджетов, которые еще только предстоит сделать. Хотя культура " +
                 "гоблинов радикально расщепилась, но репутация мало изменилась.Таким образом, " +
                 "гоблины, которые путешествуют в большие города, часто подвергаются насмешкам, " +
                 "и многие работают вдвое усерднее, чтобы доказать свою ценность. Если вам " +
                 "нужен эксцентричный, энергичный и веселый персонаж, вам следует сыграть " +
                 "гоблином.",
                 YouCanDescription = "Попытаться доказать другим, или даже себе, что у вас есть " +
                 "место среди других цивилизованных народов. Сражаться изо всех сил, даже " +
                 "кусаться и царапаться, чтобы защитить себя и своих друзей от опасности. " +
                 "Облегчить тяжелое эмоциональное бремя, которое несут другие(и развлечь себя) " +
                 "своими выходками и шалостями",
                 OtherMaybeDescription = "Пытаются убедиться, что вы случайно (или намеренно) " +
                 "не подожгли слишком много вещей. Предполагают что вы не умеете, или не " +
                 "хотите читать. Задаются вопросом, как вы выживаете, учитывая типичный " +
                 "гастрономический выбор ваших предков, безрассудное поведение и любовь к огню",
                 PhisicalDescription = "Гоблины - коренастые гуманоиды имеющие большие тела, " +
                 "худощавые конечности, и огромные головы с большими ушами и красными " +
                 "глазами-бусинками. Цвет кожи варьируется от зеленого до серого и синего, " +
                 "и они часто имеют шрамы, фурункулы и сыпь. Средняя высота гоблинов - 3 фута. " +
                 "Большинство из них лысые, с небольшой или вовсе отсутствующей " +
                 "растительностью на теле. Их неровные зубы постоянно выпадают и отрастают, " +
                 "а быстрый обмен веществ означает, что они постоянно едят и часто дремлют. " +
                 "Мутации также более распространены среди гоблинов, чем у других народов, " +
                 "и гоблины обычно рассматривают особенно выдающиеся мутации как признак " +
                 "власти или удачи. Гоблины достигают подросткового возраста к 3 годам, а " +
                 "зрелости через 4 или 5 лет.Гоблины могут жить 50 лет или более, но если не " +
                 "защищать их друг от друга, или от самих себя, немногие живут дольше 20 лет.",
                 HealthPoints = 6,
                 Speed = 25,
             },
             new DBAncestry
             {
                 ID = AncestryType.Elf,
                 Name = "Эльф",
                 Description = "Эльфы сочетают внеземную грацию, остроту интеллекта и " +
                 "мистический шарм, таким образом, что это притягательно для представителей " +
                 "других народов. Они часто жадны до размышлений, хотя их исследования " +
                 "углубляются в такой уровень подробностей, который большинство короткоживущих " +
                 "народов считают излишним или неэффективным. Ценя доброту и красоту, " +
                 "эльфы всегда стремятся улучшить свои манеры, внешний вид и культуру. " +
                 "Зачастую эльфы довольно замкнутый народ, погруженные в тайны своих рощ и " +
                 "родственных сообществ.Они не спешат заводить дружбу с представителями не " +
                 "своего народа, но по определенной причине: они тонко и глубоко привязываются " +
                 "к своему окружению и товарищам.В этой привязанности есть физический элемент," +
                 " но он не только поверхностный.Эльфы, которые проводят свою жизнь среди " +
                 "короткоживущих народов, часто развивают искаженное восприятие собственной " +
                 "смертности и склонны становиться угрюмыми, наблюдая за тем, как поколение " +
                 "за поколением их товарищи стареют и умирают.Таких эльфов называют " +
                 "Покинутыми. Если вы хотите, чтобы персонаж был волшебным, мистическим и " +
                 "таинственным, вы должны играть эльфом.",
                 YouCanDescription = "Тщательно контролировать свои отношения с людьми с более" +
                 " короткой продолжительностью жизни, либо сохраняя безопасную эмоциональную " +
                 "дистанцию, либо смиряясь с тем, что переживете их. Принимать " +
                 "специализированные или неясные интересы, просто, чтобы овладеть ими в " +
                 "совершенстве. Обладать такими особенностями, как цвет глаз, тон кожи, волосы, " +
                 "или манеры, которые отражают окружение, в котором вы живете",
                 OtherMaybeDescription = "Сосредотачиваются на вашей внешности, либо восхищаясь " +
                 "вашей грацией, либо обращаясь с вами так, как будто вы физически хрупки. " +
                 "Предполагают, что вы практикуетесь в стрельбе из лука, сотворяете заклинания, " +
                 "сражаетесь с демонами и совершенствуетесь в одном или нескольких изящных " +
                 "искусств. Беспокоятся,  что вы смотрите на них сверху вниз или чувствуют, " +
                 "что вы снисходительны и отчужденны",
                 PhisicalDescription = "Будучи в подавляющем случае выше людей, эльфы обладают " +
                 "изящным сложением, подчеркнутыми вытянутыми чертами лица и длинными " +
                 "заостренными ушами. Их глаза широкие и миндалевидные, с большими яркими " +
                 "цветными зрачками, которые составляют всю видимую часть глаза. Эти зрачки " +
                 "делают их похожими на пришельцев, и позволяют им остро видеть в тусклом " +
                 "свете. Эльфы постепенно приспосабливаются к окружающей среде и своим " +
                 "спутникам, и часто приобретают физические черты, отражающие их окружение. " +
                 "Например, у эльфа, веками жившего в первобытных лесах, могут проявиться " +
                 "зеленые волосы и сучковатые пальцы, а у того, кто жил в пустыне - золотистые " +
                 "зрачки и кожа.Эльфийская мода, как и сами эльфы, имеет тенденцию отражать " +
                 "их окружение.Эльфы, живущие в лесах и других диких местностях, носят одежду, " +
                 "которая подыгрывает ландшафту и флоре их домов, в то время как те, кто " +
                 "живет в городах, как правило, носят одежду по последней моде. Эльфы " +
                 "достигают физической зрелости примерно в возрасте 20 лет, хотя другие эльфы " +
                 "не считают их полностью эмоционально зрелыми до конца их первого века, пока " +
                 "они не испытали больше, имели несколько специализаций, и пережили " +
                 "поколение короткоживущих народов.Типичный эльф может жить около 600 лет.",
                 HealthPoints = 6,
                 Speed = 30,
             },
             new DBAncestry
             {
                 ID = AncestryType.Human,
                 Name = "Человек",
                 Description = "Амбиции, универсальность и исключительный потенциал людей " +
                 "привели к тому, что они стали доминирующим народом. Их империи и нации " +
                 "обширны, расползаются повсюду, а их жители прославляют себя силой меча и " +
                 "мощью своих заклинаний. Человечество разнообразно и энергично, среди них " +
                 "можно встретить кочевников и имперцев, злодеев и святых. Многие из них " +
                 "рискуют отправиться в исследования, составлять карту просторов " +
                 "мультивселенной, искать давно потерянное сокровище или привести могучие " +
                 "армии к завоеванию своих соседей, не по какой-то особой причине, а " +
                 "просто потому что они могут. Если вы хотите персонажа, который может быть " +
                 "кем угодно, вы должны играть человеком.",
                 YouCanDescription = "Стремиться к достижению величия, либо потому что это ваше " +
                 "желание, либо так требует дело. Стремиться понять свою цель в мире. Беречь " +
                 "ваши отношения с семьей и друзьями",
                 OtherMaybeDescription = "Уважают вашу гибкость, приспособляемость и в " +
                 "большинстве случаев вашу непредубежденность. Не доверяют вашим намерениям, " +
                 "боясь, что вы стремитесь только к власти или богатству. Не уверены, что " +
                 "ожидать от вас, и сомневаются помогать ли вашим стремлениям",
                 PhisicalDescription = "Физические характеристики людей также разнообразны, " +
                 "как и мировой климат. Люди имеют большое разнообразие цветов кожи и волос, " +
                 "форм тела и растительности на лице. В общем, их кожа имеет более темный " +
                 "оттенок по мере приближения к району экватора, где жили они или их предки. " +
                 "Люди достигают физического взросления в районе 15 лет, хотя умственная " +
                 "зрелость происходит несколькими годами позднее.Типичный человек может жить " +
                 "до 90 лет.Люди обычно вступают в брак с представителями других родословных, " +
                 "рождая детей наследующих черты обоих родителей.Наиболее примечательные " +
                 "полукровки это полуэльфы и полуорки.",
                 HealthPoints = 8,
                 Speed = 25,
             }
            );

            #endregion

            #region Haritages

            modelBuilder.Entity<DBHaritage>().HasData(
             new DBHaritage
             {
                 ID = HaritageType.AncientBloodedDwarf,
                 Name = "Дварф древней крови",
                 Description = "Дварфские герои прошлого могли избавиться от магии своих " +
                 "врагов, и часть этой сопротивляемости проявляется в вас. Вы получаете реакцию " +
                 "Зов древней крови.",
                 AncestryID = AncestryType.Dwarf,
             },
             new DBHaritage
             {
                 ID = HaritageType.DeathWardenDwarf,
                 Name = "Дварф страж гробниц",
                 Description = "Ваши предки в течение многих поколений были хранителями " +
                 "гробниц, и к вам перешла сила, которую они культивировали, чтобы защищаться " +
                 "от некромантии. Если при броске спасброска против эффекта некромантии вы " +
                 "получаете успех, то вместо этого он становится крит.успехом.",
                 AncestryID = AncestryType.Dwarf
             },
             new DBHaritage
             {
                 ID = HaritageType.RazortoothGoblin,
                 Name = "Острозубый гоблин",
                 Description = "В вашем роду, зубы - грозное оружие. Вы получаете безоружную " +
                 "атаку челюстями, которая наносит 1d6 колющего урона. Она относится к группе " +
                 "'драка' и имеет признаки точное и безоружное.",
                 AncestryID = AncestryType.Goblin
             },
             new DBHaritage
             {
                 ID = HaritageType.UnbreakableGoblin,
                 Name = "Несокрушимый гоблин",
                 Description = "Вы можете легко оправиться от травм благодаря исключительно " +
                 "толстому черепу, хрящевым костям или другим смешанным особенностям. Вы " +
                 "получаете 10 Очков Здоровья от своей родословной, вместо стандартных 6. " +
                 "Когда вы падаете, снизьте получаемый урон от падения, как если бы вы " +
                 "падали только половину расстояния.",
                 AncestryID = AncestryType.Goblin
             },
             new DBHaritage
             {
                 ID = HaritageType.CavernElf,
                 Name = "Пещерный эльф",
                 Description = "Вы родились или провели много лет в подземных туннелях или " +
                 "пещерах, где недостаточно света. Вы получаете ночное зрение.",
                 AncestryID = AncestryType.Elf
             },
             new DBHaritage
             {
                 ID = HaritageType.WoodlandElf,
                 Name = "Лесной эльф",
                 Description = "Вы приспособлены к жизни в лесу или глубоких джунглях, и " +
                 "знаете как лазить по деревьям и использовать растительность в своих " +
                 "интересах. Когда вы Карабкаетесь на деревья, лианы и другую растительность, " +
                 "вы двигаетесь с половиной своей Скорости при успехе, и полной Скоростью при " +
                 "критическом успехе (и если у вас есть Быстро карабкаться, вы двигаетесь с " +
                 "полной Скоростью при успехе). Если вы используете Скорость карабканья, эти " +
                 "бонусы не применяются. Вы всегда можете использовать действие Укрыться, " +
                 "когда находитесь в лесной местности, чтобы получить укрытие, даже если вы " +
                 "не рядом с преградой, за которой можете Укрыться.",
                 AncestryID = AncestryType.Elf
             },
             new DBHaritage
             {
                 ID = HaritageType.SkilledHeritage,
                 Name = "Умелый",
                 Description = "Ваша изобретательность позволяет вам обучаться самым разным " +
                 "навыкам. Вы обучаетесь одному навыку на свой выбор. На 5-м уровне " +
                 "вы становитесь экспертом выбранного навыка.",
                 AncestryID = AncestryType.Human
             },
             new DBHaritage
             {
                 ID = HaritageType.VersatileHeritage,
                 Name = "Разносторонний",
                 Description = "Многогранность и амбиции человечества способствовали тому, что " +
                 "они стали самой распространенной родословной в большинстве наций мира. " +
                 "Выберите общую способность для которой вы подходите по предварительным " +
                 "условиям (как и в случае со способностью родословной, вы можете выбрать " +
                 "эту способность на любом этапе создания персонажа).",
                 AncestryID = AncestryType.Human
             }
            );

            #endregion

            #region Backgrounds

            modelBuilder.Entity<DBBackground>().HasData(
                new DBBackground
                {
                    ID = BackgroundType.Acolyte,
                    Name = "Аколит",
                    Description = "Вы провели свои ранние годы в религиозном монастыре или " +
                    "в уединении. Возможно, вы отправились в этот мир, чтобы распространять " +
                    "слово своей религии, или потому, что вы отвергли учения своей веры, но " +
                    "в глубине души, те уроки, которые вы извлекли, всегда будут с вами.",
                    SkillTrained = SkillType.Religion,
                    FeatTrained = "Student of the Canon"
                },
                new DBBackground
                {
                    ID = BackgroundType.Charlatan,
                    Name = "Шарлатан",
                    Description = "Вы путешествовали с места на место, в одном городе " +
                    "приторговывая липовыми магическими безделушками и змеиным маслом, " +
                    "а в следующем притворяясь королевской семьей в изгнании, чтобы " +
                    "соблазнить богатого наследника. Становление авантюристом может быть " +
                    "вашей следующей большой аферой или попыткой использовать свои таланты " +
                    "для более важной цели. А возможно, и то и другое, поскольку вы понимаете, " +
                    "что притворство героем - лишь маска.",
                    SkillTrained = SkillType.Deception,
                    FeatTrained = "Charming Liar"
                },
                new DBBackground
                {
                    ID = BackgroundType.Criminal,
                    Name = "Преступник",
                    Description = "Вы жили преступной жизнью, будучи недобросовестным " +
                    "независимым человеком или членом преступной организации. Вы могли " +
                    "бы стать авантюристом, чтобы искать искупления, избежать закона или " +
                    "просто получить доступ к большей и лучшей добыче.",
                    SkillTrained = SkillType.Stealth,
                    FeatTrained = "Experienced Smuggler"
                },
                new DBBackground
                {
                    ID = BackgroundType.FieldMedic,
                    Name = "Полевой врач",
                    Description = "В хаосе битвы вы научились адаптироваться к быстро " +
                    "меняющимся условиям, управляя боевыми потерями. Вы латали солдат, " +
                    "охранников или других участников боевых действий и многое узнали " +
                    "о военной логистике.",
                    SkillTrained = SkillType.Medicine,
                    FeatTrained = "Battle Medicine"
                }
            );

            #endregion

            #region Deities

            modelBuilder.Entity<DBDeity>().HasData(
                new DBDeity
                {
                    ID = DeityType.CaydenCailean,
                    Name = "Кайдэн Кайлин",
                    Description = "Пьяный Герой вознесся в пьяном виде, став богом эля, " +
                    "свободы и вина. Кайдэн поощряет свободу и побуждает других искать свой " +
                    "собственный жизненный путь. Он борется за правое дело и наслаждается " +
                    "потворствуя своим желаниям.Когда-то Кайдэн Кайлиан был смертным " +
                    "человеком, а теперь стал одним из немногих божеств, известных как " +
                    "Вознесшиеся. В свои смертные годы Кайдэн был наемником немалой славы, " +
                    "известным своими неистовыми манерами, умением обращаться с клинком и " +
                    "бесстрашной решимостью. Во время особенно буйной ночи пьянства череда " +
                    "все возрастающей дерзости привела к тому, что странствующий наемник " +
                    "попытался пройти Испытание Звездного Камня. Спустя 3 дня, он смеясь " +
                    "вышел из Собора Звездного Камня, полностью осознавший себя богом. " +
                    "Божественная ответственность мало что изменила в отношении Кайдэна по " +
                    "сравнению с тем, каким он был в своей смертной жизни. Он продолжает " +
                    "жаждать приключений, выпивки и приятной компании, ненавидя хулиганов, " +
                    "тиранов и трусов."
                },
                new DBDeity
                {
                    ID = DeityType.ZonKuthon,
                    Name = "Зон-Кутон",
                    Description = "Владыка Полуночи - бог тьмы, зависти, потерь и боли. " +
                    "Некогда, как и Шелин, бог искусства, красоты и музыки, он вернулся из " +
                    "странствия в темных пространствах между планами, ужасно изменившись. " +
                    "Владыка Полуночи воплощает и прославляет боль, тени и увечья, и он " +
                    "является одним из самых извращенных и злобных богов на лице Голариона. " +
                    "Когда - то известный как Ду - Брал, он создал огромные Звездные Башни, " +
                    "которые до сих пор помогают удерживать Ровагуга в его тюрьме в сердце " +
                    "Голариона, предоставив свои навыки и умения великому божественному " +
                    "альянсу, чтобы связать это злое существо.И все же божественный спор " +
                    "между ним и его сестрой Шелин(Shelyn) привел к тому, что бог ушел в " +
                    "неизвестные места.Зон - Кутон путешествовал за грани мультивселенной и " +
                    "смотрел в лицо непостижимым вещам, обитающим там.Никто не знает что он " +
                    "нашел в том месте, но он вернулся, изменившийся, но утверждающий, что " +
                    "пережитое укрепило его.Точно так же нация Нидала на Голарионе, связанная с " +
                    "ним, -это нация выживших, основанная теми немногими, которые достаточно " +
                    "сильны, чтобы сделать необходимое, чтобы их люди могли пережить ужасные " +
                    "последствия Землепада и последовавшей Эпохи Тьмы."
                },
                new DBDeity
                {
                    ID = DeityType.Iomedae,
                    Name = "Иомедай",
                    Description = "Айомедэй - богиня чести, справедливости, власти и доблести, " +
                    "и ее называют Наследницей, потому что она унаследовала свою мантию, когда " +
                    "погиб бог человечества. До своего вознесения, Айомедэй ходила по планете " +
                    "как смертная. Многие паладины следуют ее вере. Айомедэй, самая молодая из " +
                    "выдающихся божеств региона Внутреннего моря, уже доказала, что достойна " +
                    "божественности до своего вознесения.Родившись в Челии, она пошла по пути " +
                    "меча и борьбы со злом, в конечном итоге став паладином Аразни, вестницы " +
                    "Ародена.Она стала легендой 'Сияющего Поход', возглавив Рыцарей Озэма в " +
                    "серии побед над Шепчущим Тираном.Айомедэй стала третьим известным " +
                    "смертным, прошедшим Испытание Звездного Камня, когда она вознеслась в " +
                    "3832 году нашей эры.Поскольку Аразни была убита во время " +
                    "'Сияющего Похода', Ароден возвысил недавно вознесшуюся богиню в качестве " +
                    "своего нового вестника.Когда умер сам Ароден, Айомедэй унаследовал " +
                    "большинство молящихся ему и стала главным божеством чести и справедливости."
                },
                new DBDeity
                {
                    ID = DeityType.Lamashtu,
                    Name = "Ламашту",
                    Description = "Мать Монстров - богиня аберраций, чудовищ и кошмаров. Она " +
                    "стремится развратить смертных и населить мир своим извращенным и " +
                    "чудовищным выводком. Тем, кто упивается чистой порочностью или кто " +
                    "оказывается отвергнутым и пренебрегаемым миром, презирающим их различия, " +
                    "Ламашту предлагает передышку среди своего гротескного выводка.Мать " +
                    "Монстров с готовностью принимает смертных в свою паству и поставила своей" +
                    " целью обратить смертную жизнь в свои отвратительные идеалы.Широко " +
                    "известно, что ее вмешательство вызывает развращение и ужасные кошмары. " +
                    "Изгнанники общества, разделяющие ее идеалы, сочтут это вмешательство " +
                    "благом, в то время как другие расценивают подобные события как " +
                    "ужасные проклятия."
                }
                );

            #endregion

            #endregion

            #region Feats

            modelBuilder.Entity<DBFeat>().HasData(

            #region GeneralFeats

            #region Level1

                new DBFeat
                {
                    Name = "Adopted ancestry",
                    RussianName = "Заимствованная родословная",
                    Description = "Вы полностью погружены в культуру и традиции другой " +
                    "родословной, независимо от того, родились ли вы среди нее, заработали " +
                    "через обряд посвящения, или связаны глубокой дружбой или романом. " +
                    "Выберите распространенную (обычную) родословную. Когда вы выбираете " +
                    "способности родословной, то в дополнение к родословной своего персонажа, " +
                    "вы можете выбирать из выбранной вами здесь, если только способности " +
                    "родословной не требуют любых отсутствующих у вас физиологических " +
                    "особенностей (на усмотрение Мастера).",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Armor proficiency",
                    RussianName = "Ношение доспехов",
                    Description = "Вы становитесь обучены ношению легких доспехов. Если вы уже " +
                    "были обучены легким доспехам, то обучаетесь средним доспехам. Если вы уже " +
                    "были обучены обоим видам доспехов, то обучаетесь тяжелым доспехам. " +
                    "Особенность: Вы можете выбирать эту способность более 1 раза. Каждый " +
                    "раз вы становитесь обучены ношению следующего вида доспехов.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Breath control",
                    RussianName = "Задержка дыхания",
                    Description = "Вы умеете невероятно задерживать дыхание, что дает вам " +
                    "преимущества когда воздух опасен или разряжен. Вы можете задержать " +
                    "дыхание на время в 25 раз дольше, чем обычно, прежде чем начнете " +
                    "задыхаться. Вы получаете бонус обстоятельства +1 к спасброскам против " +
                    "вдыхаемых угроз, таких как вдыхаемые яды, и если при броске такого " +
                    "спасброска вы получаете успех, то вместо этого он считается критическим " +
                    "успехом.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Canny acumen - Perception",
                    RussianName = "Проницательность - Восприятие",
                    Description = "Ваша проницательность или внимательность находится за " +
                    "пределами понимания большинства представителей вашей профессии. " +
                    "Вы получаете уровень мастерства эксперта для бросков Восприятия. " +
                    "На 17-м уровне, вы становитесь мастером того что выбрали.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Canny acumen - Fortitude",
                    RussianName = "Проницательность - Стойкость",
                    Description = "Ваша проницательность или внимательность находится за " +
                    "пределами понимания большинства представителей вашей профессии. " +
                    "Вы получаете уровень мастерства эксперта для бросков Стойкости. " +
                    "На 17-м уровне, вы становитесь мастером того что выбрали.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Canny acumen - Reflex",
                    RussianName = "Проницательность - Реакция",
                    Description = "Ваша проницательность или внимательность находится за " +
                    "пределами понимания большинства представителей вашей профессии. " +
                    "Вы получаете уровень мастерства эксперта для бросков Реакции. " +
                    "На 17-м уровне, вы становитесь мастером того что выбрали.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Canny acumen - Will",
                    RussianName = "Проницательность - Воля",
                    Description = "Ваша проницательность или внимательность находится за " +
                    "пределами понимания большинства представителей вашей профессии. " +
                    "Вы получаете уровень мастерства эксперта для бросков Воли. " +
                    "На 17-м уровне, вы становитесь мастером того что выбрали.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Diehard",
                    RussianName = "Несгибаемый",
                    Description = "Вас убить тяжелее, чем остальных. Вы умираете при состоянии " +
                    "\"при смерти 5\", а не при смерти 4.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Fast recovery",
                    RussianName = "Быстрое восстановление",
                    Description = "Ваше тело быстрее восстанавливается от недугов. Вы " +
                    "восстанавливаете в 2 раза больше Очков Здоровья от отдыха. Каждый раз, " +
                    "когда вы успешно проходите спасбросок Стойкости против действующей " +
                    "болезни или яда, то снижаете их стадию на 2, или на 1 против вирулентной " +
                    "болезни или яда. Каждый получаемый вами критический успех против " +
                    "действующей болезни или яда, снижает их стадию на 3, или на 2 против " +
                    "вирулентной болезни или яда. Кроме того, когда вы отдыхаете целую ночь, " +
                    "то снижаете значение состояния истощен на 2, а не на 1.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Fleet",
                    RussianName = "Быстроногий",
                    Description = "Вы можете двигаться быстрее. Ваша Скорость увеличивается " +
                    "на 5 футов.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Feather step",
                    RussianName = "Лёгкий шаг",
                    Description = "Вы шагаете быстро и осторожно. Вы можете сделать Шаг на " +
                    "сложную местность.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Incredeble initiative",
                    RussianName = "Невероятная инициатива",
                    Description = "Вы реагируете быстрее, чем могут другие. Вы получаете бонус " +
                    "обстоятельства +2 к броскам инициативы.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Ride",
                    RussianName = "Езда верхом",
                    Description = "Когда вы Командуете животному на котором находитесь верхом, " +
                    "чтобы оно использовало действие с признаком движение (такое как " +
                    "Перемещение), то вы автоматически получаете успех без необходимости " +
                    "выполнять проверку. Любое животное, на котором вы верхом, действует в " +
                    "ваш ход как миньон. Если вы Седлаете (Mount) животное посреди " +
                    "столкновения, оно пропускает свой следующий ход и потом действует в " +
                    "ваш следующий ход (см. больше информации в описании действия Команда " +
                    "животному).",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Shield block",
                    RussianName = "Блок щитом",
                    Description = "Вы выставляете свой щит, чтобы защититься от удара. Ваш щит" +
                    " защищает вас от части урона, равной вплоть до значения Твердости щита. " +
                    "Щит и вы, вместе получаете любой оставшийся непоглощенный урон, возможно в " +
                    "результате чего щит ломается или уничтожается.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Toughness",
                    RussianName = "Живучесть",
                    Description = "Вы можете выдержать больше ударов, чем большинство. " +
                    "Увеличьте ваши максимальные Очки Здоровья на значение вашего уровня. " +
                    "Ваш КС проверок восстановления становится равным 9 + ваше значения " +
                    "состояния при смерти (Проверки восстановления).",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Weapon proficiency",
                    RussianName = "Владение оружием",
                    Description = "Вы становитесь обучены всему простому оружию. Если вы уже " +
                    "были обучены всему простому оружию, то обучаетесь обращению с воинским " +
                    "оружием. Если вы уже были обучены всему воинскому оружию, то обучаетесь " +
                    "1 продвинутому оружию на свой выбор. Особенность: Вы можете выбрать " +
                    "эту способность более одного раза. Каждый раз когда вы это делаете, то " +
                    "обучаетесь дополнительному виду оружий, в соответствии с прогрессией из " +
                    "описания способности.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },

            #endregion

            #region Level3

                new DBFeat
                {
                    Name = "Ancestral paragon",
                    RussianName = "Наследник рода",
                    Description = "Будь то инстинкт, учеба или магия, но вы чувствуете более " +
                    "глубокую связь со своей родословной. Вы получаете способность " +
                    "родословной 1-го уровня.",
                    Level = 3,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },
                new DBFeat
                {
                    Name = "Untrained improvisation",
                    RussianName = "Импровизация без тренировки",
                    Description = "Вы научились справляться с ситуациями которые вам не по " +
                    "зубам. Ваш бонус мастерства для проверок навыков которым вы нетренированы, " +
                    "равняется половине вашего уровня, вместо +0. Если вы 7-го уровня или " +
                    "выше, то вместо этого бонус увеличивается до значения вашего уровня. " +
                    "Это не позволяет вам использовать действия навыков для которых требуется " +
                    "быть обученным.",
                    Level = 3,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },

            #endregion

            #region Level7

                new DBFeat
                {
                    Name = "Expeditious search",
                    RussianName = "Оперативный поиск",
                    Description = "У вас есть система, позволяющая искать с большой скоростью, " +
                    "находя подробности и секреты в 2 раза быстрее, чем могут другие. Когда " +
                    "вы Ищете, то обыск области занимает половину обычного времени. Это " +
                    "означает, что во время исследования вы удваиваете Скорость с которой " +
                    "можете двигаться, гарантируя, что вы Обыскали область прежде, чем " +
                    "наткнетесь на что-либо (вплоть до половины вашей скорости). Если у " +
                    "вас легендарное Восприятие, то вы обыскиваете области в 4 раза быстрее." +
                    "(прим.пер: В предпоследнем предложении имеется в виду, то, что если бы вы " +
                    "обыскивали область с ловушками и в результате проверки заметили бы их, или " +
                    "какую-то их часть, но не попали бы в них, заметите затаившегося противника " +
                    "и т.п.)",
                    Level = 7,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },

            #endregion

            #region Level11

                new DBFeat
                {
                    Name = "Incredible investiture",
                    RussianName = "Невероятное облачение",
                    Description = "У вас есть невероятное умение инвестировать больше " +
                    "магических предметов. Увеличьте ваше ограничение инвестируемых " +
                    "магических предметов с 10 до 12.",
                    Level = 11,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.General
                },

            #endregion

            #region Level19



            #endregion

            #endregion

            #region SkillFeats

            #region VaryingSkillFeats

                new DBFeat
                {
                    Name = "Assurance",
                    RussianName = "Уверенность",
                    Description = "Вы можете выполнять основные задачи даже в худших " +
                    "обстоятельствах. Выберите навык которому вы обучены. Вы можете отказаться " +
                    "от броска проверки навыка и вместо этого просто использовать результат " +
                    "10 + ваш бонус мастерства (не применяйте другие бонусы, штрафы или " +
                    "модификаторы). Особенность: Вы можете выбирать эту способность несколько " +
                    "раз. Каждый раз выбирайте другой навык и получайте преимущества для него.",
                    Level = 1,
                    Traits = new List<FeatTraits> { FeatTraits.Fortune },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Dubious knowledge",
                    RussianName = "Сомнительные знания",
                    Description = "Вы - кладезь информации, но она не вся заслуживает доверия. " +
                    "Когда вы проваливаете проверку (но не критически проваливаете) при " +
                    "использовании Вспомнить информацию с любым навыком, " +
                    "то узнаете часть правдивой информации и часть ложной, но у вас нет " +
                    "способа отличить что есть что.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Quick identification",
                    RussianName = "Быстрая идентификация",
                    Description = "Вы можете быстро Идентификация магии. Вам требуется только " +
                    "1 минута, вместо 10, на \"Идентификацию магии\" для выяснения свойств " +
                    "предмета, действующего эффекта или локации. Если вы мастер, для этого " +
                    "требуется активность в 3 действия (активность из 3-х действий), а если " +
                    "вы легенда, то только 1 действие (одиночное действие).",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Recognize spell",
                    RussianName = "Распознание заклинания",
                    Description = "Если вы обучены навыку соответствующему колдовскому обычаю " +
                    "заклинания, и это обычное заклинание 2-го уровня или ниже, то вы " +
                    "автоматически идентифицируете его (вы все еще можете совершить бросок в " +
                    "попытке получить критический успех, но не можете получить результат хуже " +
                    "простого успеха). Наивысшие уровни заклинания, которые вы можете " +
                    "автоматически идентифицировать увеличиваются до 4-го, если вы эксперт, " +
                    "6-го если мастер, и 10-го если легенда навыка. Мастер совершает тайный " +
                    "бросок Арканы, Природы, Оккультизма или Религии, в зависимости от " +
                    "соответствующего обычая сотворенного заклинания. Если вы нетренированы " +
                    "навыку, то не можете получить результат лучше провала.",
                    Level = 1,
                    Traits = new List<FeatTraits> { FeatTraits.Secret },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Skill training",
                    RussianName = "Обучение навыку",
                    Description = "Вы обучаетесь навыку по своему выбору. Особенность: Вы " +
                    "можете выбрать эту способность несколько раз, каждый раз выбирая новый " +
                    "навык которому вы обучитесь.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Automatic knowledge",
                    RussianName = "Автоматическое знание",
                    Description = "Вы знаете основные факты, не задумываясь. Выберите навык, " +
                    "который имеет действие Вспомнить информацию, в котором вы эксперт, " +
                    "и для которого у вас есть способность Уверенность. Вы можете использовать " +
                    "Вспомнить информацию с этим навыком, как свободное действие, раз в раунд. " +
                    "Если вы так делаете, то должны использовать Уверенность для проверки навыка." +
                    "Особенность: Вы можете выбрать эту способность несколько раз, каждый раз " +
                    "выбирая другой навык. Вы можете использовать ее с любыми выбранными вами " +
                    "навыками, но все еще только 1 раз в раунд.",
                    Level = 2,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Magical shorthand",
                    RussianName = "Магическая скоропись",
                    Description = "Вам легко дается изучение заклинаний. Если вы эксперт навыка, " +
                    "связанного с колдовским обычаем, то тратите на изучение 10 минут за уровень " +
                    "заклинания, вместо 1 часа за уровень. Если вы проваливаете изучение заклинания, " +
                    "то можете попытаться снова через 1 неделю или после получения уровня, " +
                    "в зависимости от того, что произойдет раньше. Если вы мастер навыка, связанного " +
                    "с колдовским обычаем, то изучение занимает 5 минут за уровень заклинания, а если " +
                    "легенда, то это занимает 1 минуту за уровень заклинания. Вы можете использовать " +
                    "время режима отдыха, чтобы выучить и записать новые заклинания. Это работает так, " +
                    "как если бы вы выполняли Заработок денег используя навык относящийся к колдовскому " +
                    "обычаю, но вместо получения денег, вы выбираете заклинание доступное вам для " +
                    "изучения и получаете скидку на изучение, или изучаете бесплатно, если ваш доход " +
                    "больше или равен стоимости заклинания.",
                    Level = 2,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Quick recognition",
                    RussianName = "Быстрое распознавание",
                    Description = "Вы быстро используете Распознание заклинания. Вы можете раз в раунд " +
                    "применить Распознание заклинания свободным действием, используя навык мастером " +
                    "которого являетесь.",
                    Level = 7,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },

            #endregion

            #region AcrobaticsSkillFeats

                new DBFeat
                {
                    Name = "Cat fall",
                    RussianName = "Кошачье падение",
                    Description = "Ваша кошачья воздушная акробатика позволяет смягчать " +
                    "падения. Считайте падения на 10 футов короче. Если вы эксперт Акробатики " +
                    "- на 25 футов короче; мастер - 50 футов короче. Если вы легенда " +
                    "Акробатики, то всегда приземляетесь на ноги и не получаете урон, " +
                    "независимо от расстояния падения.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Quick squeeze",
                    RussianName = "Быстро протиснуться",
                    Description = "Вы можете Протиснуться на 5 футов за раунд " +
                    "(10 футов при критическом успехе). Если вы легенда Акробатики, то " +
                    "Протискиваетесь используя свою полную Скорость.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Steady balance",
                    RussianName = "Твёрдое равновесие",
                    Description = "Вы можете легко сохранять равновесие, даже в " +
                    "неблагоприятных условиях. Всякий раз, когда вы при броске получаете " +
                    "успех проверки действия Балансировать, то вместо этого " +
                    "получаете критический успех. Вы не считаетесь застигнуты врасплох, " +
                    "когда пытаетесь Балансировать на узкой и неровной земле. Благодаря " +
                    "вашему невероятному чувству равновесия, вы можете совершать проверку " +
                    "Акробатики вместо спасброска Рефлекса, чтобы Схватиться за уступ.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Acrobatic performer",
                    RussianName = "Акробатическое выступление",
                    Description = "Вы невероятный акробат, вызывающий удивление и восхищающий " +
                    "публику своим мастерством. Это почти выступление! Вы можете кидать " +
                    "проверку Акробатики вместо проверки Выступления, когда используете " +
                    "действие Выступить.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Nimble crawl",
                    RussianName = "Шустро ползать",
                    Description = "Вы можете необычайно быстро Ползти, вплоть до половины " +
                    "вашей Скорости, а не на 5 футов. Если вы мастер Акробатики, то можете " +
                    "Ползти с полной Скоростью, а если вы легенда Акробатики, то не считаетесь " +
                    "застигнутым врасплох когда лежите ничком.",
                    Level = 2,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Kip up",
                    RussianName = "Подъём разгибом",
                    Description = "Вы встаете. Это действие не провоцирует реакции.",
                    Level = 7,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "",
                    RussianName = "",
                    Description = "",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },

            #endregion

            #region ArcanaSkillFeats

                new DBFeat
                {
                    Name = "Arcane sense",
                    RussianName = "Арканное чутье",
                    Description = "Ваше изучение магии позволяет вам инстинктивно ощущать " +
                    "ее присутствие. Вы можете по желанию колдовать Обнаружение магии 1-го уровня, " +
                    "как врожденное арканное заклинание. Если вы мастер Арканы, то заклинание " +
                    "усиливается до 3-го уровня; если легенда - до 4-го уровня.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Unified theory",
                    RussianName = "Единая теория",
                    Description = "Вы начали создавать осмысленную связь между общими основами четырех " +
                    "магических обычаев и магических сущностей, что позволяет вам понять их все сквозь " +
                    "призму арканы. Всякий раз, когда вы используете действие навыка или способность навыка, " +
                    "требующую в зависимости от магического обычая совершить проверку Природы, Оккультизма " +
                    "или Религии, то вы вместо этого можете использовать Аркану. Если бы вы обычно получали " +
                    "штраф или имели более высокий КС при использовании Арканы для другой магии (как " +
                    "когда используете Идентификация магии, то вы больше не получаете его.",
                    Level = 15,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },

            #endregion

            #region AthleticsSkillFeats

                new DBFeat
                {
                    Name = "Combat climber",
                    RussianName = "Боевой альпинист",
                    Description = "Ваши приемы позволяют вам сражаться, когда вы карабкаетесь. " +
                    "Вы не застигнуты врасплох когда карабкаетесь и можете Карабкаться с занятой рукой. " +
                    "Вы все еще должны использовать другую руку и обе ноги, чтобы Карабкаться.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Hefty hauler",
                    RussianName = "Сильный носильщик",
                    Description = "Вы можете нести больше, чем предполагает ваше телосложение. " +
                    "Увеличьте свои ограничения максимальной Массы и перегрузки на 2.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Quick jump",
                    RussianName = "Быстрый прыжок",
                    Description = "Вы можете использовать Прыжок в высоту и Прыжок в длину" +
                    "как одиночное действие, вместо 2 действий. Если вы так делаете, то не выполняете " +
                    "начальное Перемещение (и вы не получите провал, если не Переместитесь на 10 футов).",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Titan wrestler",
                    RussianName = "Борец с титанами",
                    Description = "Вы можете попытаться Разоружить, Захватить, Толкнуть или Опрокинуть " +
                    "существо вплоть до 2-х размеров больше вас или, если вы легенда Атлетики, " +
                    "то вплоть до 3-х размеров больше.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Underwater marauder",
                    RussianName = "Подводный мародер",
                    Description = "Вы научились сражаться под водой. Вы не застигнуты врасплох когда " +
                    "в воде, и вы не получаете обычные штрафы используя в воде дробящее или рубящее " +
                    "оружие ближнего боя.",
                    Level = 1,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Powerful leap",
                    RussianName = "Мощный прыжок",
                    Description = "Когда вы совершаете Прыжок, то можете прыгать на 5 футов " +
                    "вертикальным Прыжком, и на 5 футов увеличиваете расстояние на которое можете " +
                    "прыгать горизонтально.",
                    Level = 2,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Rapid mantel",
                    RussianName = "Быстро подтянуться",
                    Description = "Вы легко подтягиваетесь на выступах. Когда вы используете Схватиться " +
                    "за уступ, то можете подтянуться на эту поверхность и встать. Вы можете использовать " +
                    "Атлетику вместо спасброска Рефлекса для Схватиться за уступ.",
                    Level = 2,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Quick climb",
                    RussianName = "Быстро карабкаться",
                    Description = "Во время Карабканья вы двигаетесь на 5 футов дальше при успехе, " +
                    "и на 10 футов дальше при крит.успехе, вплоть до максимума равного вашей Скорости. " +
                    "Если вы легенда Атлетики, то получаете Скорость карабканья, равную вашей Скорости.",
                    Level = 7,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Quick swim",
                    RussianName = "Быстро плавать",
                    Description = "Вы Плывете на 5 футов дальше при успехе, и на 10 футов дальше при " +
                    "крит.успехе, вплоть до максимума равного вашей Скорости. Если вы легенда Атлетики, " +
                    "то получаете Скорость плавания, равную вашей Скорости.",
                    Level = 7,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Wall jump",
                    RussianName = "Прыжок от стены",
                    Description = "Вы можете использовать импульс своего прыжка, чтобы оттолкнуться от " +
                    "стены. Если вы рядом со стеной в конце прыжка (неважно, делая Прыжок в высоту, " +
                    "Прыжок в длину или простой Прыжок), то вы не падаете, если ваше следующее действие " +
                    "является еще одним прыжком. Кроме того, поскольку ваш предыдущий прыжок дает вам " +
                    "импульс, вы можете использовать Прыжок в высоту или Прыжок в длину как одиночное " +
                    "действие, но вам не надо выполнять Перемещение как часть активности. Вы можете " +
                    "использовать Прыжок от стены только раз в ход, если только вы не легенда Атлетики," +
                    "в этом случае, вы можете использовать Прыжок от стены столько раз, сколько сможете " +
                    "сделать последовательных прыжков в этот ход.",
                    Level = 7,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },
                new DBFeat
                {
                    Name = "Cloud jump",
                    RussianName = "Облачный прыжок",
                    Description = "Ваше непревзойденное мастерство атлетики позволяет вам прыгать на " +
                    "невозможные расстояния. Утройте дистанцию Прыжок в длину (так что вы можете прыгать " +
                    "на 60 футов при успешной проверке с КС 20). Когда вы совершаете Прыжок в высоту, " +
                    "используйте расчеты как для Прыжок в длину, но без утроения дистанции. Вы можете " +
                    "прыгать на расстояние больше своей Скорости, тратя дополнительные действия на Прыжок " +
                    "в длину или Прыжок в высоту. За каждое дополнительное потраченное действие, как " +
                    "далеко вы можете Прыгать.",
                    Level = 15,
                    Traits = new List<FeatTraits> { },
                    Type = FeatType.Skill,
                },

            #endregion

            #region CraftingSkillFeats

                 new DBFeat
                 {
                     Name = "Alchemical crafting",
                     RussianName = "Алхимическое ремесло",
                     Description = "Вы можете использовать активность Создать для создания " +
                     "алхимических предметов. Когда вы выбираете эту способность, то мгновенно " +
                     "добавляете в свою книгу формул, формулы 4 обычных алхимических предметов " +
                     "1-го уровня.",
                     Level = 1,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },
                 new DBFeat
                 {
                     Name = "Quick repair",
                     RussianName = "Быстрый ремонт",
                     Description = "Ваш Ремонт предмета занимает 1 минуту. Если вы мастер Ремесла, " +
                     "это занимает 3 действия. Если легенда - 1 действие.",
                     Level = 1,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },
                 new DBFeat
                 {
                     Name = "Snare crafting",
                     RussianName = "Создание силков",
                     Description = "Вы можете использовать активность Создать для создания силков, " +
                     "используя общие правила создания предметов. Когда вы выбираете эту способность, " +
                     "то добавляете формулы 4 обычных силков в свою книгу формул.",
                     Level = 1,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },
                 new DBFeat
                 {
                     //не уверена насчет правильности описания
                     Name = "Magical crafting",
                     RussianName = "Магическое ремесло",
                     Description = "Вы можете Создать магические предметы, хотя некоторые из них имеют " +
                     "другие требования, как описано в Главе 11. Ремесла и сокровища. Когда вы " +
                     "выбираете этот навык, то получаете формулы 4 обычных магических предметов " +
                     "2-го уровня или ниже.",
                     Level = 2,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },
                 new DBFeat
                 {
                     Name = "Impeccable crafting",
                     RussianName = "Безукоризненное ремесло",
                     Description = "Вы с большой эффективностью создаете безупречные творения. Всякий " +
                     "раз когда вы при броске проверки Ремесла получаете успех создания предмета того " +
                     "вида, который вы выбрали для Специализации в ремесле, то вместо этого получаете " +
                     "критический успех.",
                     Level = 2,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },
                 new DBFeat
                 {
                     Name = "Inventor",
                     RussianName = "Изобретатель",
                     Description = "Вы гений Ремесла, способный легко определить, как сделаны вещи и " +
                     "создавать новые изобретения. Вы можете потратить время режима отдыха, чтобы " +
                     "изобрести обычную формулу которую не знаете. Это работает точно так же как и " +
                     "активность Создать: вы тратите половину цены формулы наперед, совершаете проверку " +
                     "Ремесла, и при успехе либо завершаете формулу платя разницу, либо работаете " +
                     "дольше для снижения Цены. Разница в том, что вы тратите дополнительное время на " +
                     "исследование, проектирование и разработку, а не на создание предмета. По " +
                     "завершении вы добавляете изобретенную формулу в свою книгу формул.",
                     Level = 7,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },
                 new DBFeat
                 {
                     Name = "Craft anything",
                     RussianName = "Создание чего угодно",
                     Description = "Вы умеете находить способы создавать почти все, несмотря на " +
                     "ограничения. До тех пор, пока вы соответствуете требованиям уровня предмета, " +
                     "уровню мастерства, и у вас есть подходящий навык Ремесла (например, Магическое " +
                     "ремесло для создания магических предметов), то вы игнорируете почти любые другие " +
                     "требования, такие как быть определенной родословной или предоставление заклинаний. " +
                     "Единственными исключениями являются требования, увеличивающие стоимость предмета, " +
                     "включая сотворение заклинаний имеющих стоимость, и требования специальных " +
                     "предметов, таких как Философский камень, и имеют особое значение для возможности " +
                     "изготовления и Ремесла. Мастер решает, можете ли вы игнорировать требование.",
                     Level = 15,
                     Traits = new List<FeatTraits> { },
                     Type = FeatType.Skill,
                 },

            #endregion

            #region DeceptionSkillFeats

                  new DBFeat
                  {
                      Name = "Charming liar",
                      RussianName = "Очаровательный лжец",
                      Description = "Ваше обаяние позволяет вам победить тех, кому вы лжете. " +
                      "Когда вы получаете критический успех используя действие Лгать, то отношение " +
                      "цели к вам улучшается на одну ступень, как если бы вы преуспели в " +
                      "использовании Дипломатии, чтобы Произвести впечатление. Это работает только " +
                      "один раз за разговор, и если вы критически преуспели со многими целями с тем же " +
                      "результатом, вы выбираете 1 существо, чье отношение улучшится. Вы должны лгать, " +
                      "чтобы передать, казалось бы, важную информацию, преувеличивать свой статус или " +
                      "льстить другим, чего нельзя достичь тривиальной или неуместной ложью.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Lengthy diversion",
                      RussianName = "Надолго отвлечь",
                      Description = "Когда вы критически преуспеваете в использовании Отвлечь внимание, " +
                      "вы продолжаете оставаться спрятанным после окончания своего хода. На усмотрение " +
                      "Мастера, этот эффект длится период времени, зависящий от отвлечения и ситуации " +
                      "(минимум 1 дополнительный раунд).",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Lie to me",
                      RussianName = "Обмани меня",
                      Description = "Вы можете использовать Обман, чтобы плести ловушки, и подловить " +
                      "любого, кто пытается обмануть вас. Если вы вступаете в разговор с кем-то " +
                      "пытающимся Лгать вам, то, чтобы узнать могут ли они преуспеть в обмане, " +
                      "используйте ваш КС Обмана, если он больше КС Восприятия. Это не применимо, " +
                      "если вы не имеете двустороннего диалога, как когда кто-то пытается Лгать " +
                      "во время долгой речи.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Confabulator",
                      RussianName = "Патологический лжец",
                      Description = "Даже когда вас поймали на неправде, вы продолжаете нагромождать " +
                      "одну ложь на другую. Снизьте получаемый целью бонус обстоятельства за ваши " +
                      "предыдущие попытки Отвлечь внимание или Лгать ей, с +4 до +2. Если вы мастер " +
                      "Обмана, снизьте бонус до +1, а если вы легенда, то ваши цели вовсе не получают " +
                      "эти бонусы.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Quick disguise",
                      RussianName = "Быстрая маскировка",
                      Description = "Вы можете сделать маскировку за половину обычного времени (обычно " +
                      "за 5 минут). Если вы мастер, это занимает одну десятую обычного времени (обычно " +
                      "1 минуту). Если вы легенда, то можете создать полную маскировку и Перевоплотиться " +
                      "за активность в 3 действия.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Slippery secrets",
                      RussianName = "Скользкие тайны",
                      Description = "Вы избегаете и уклоняетесь от попыток раскрыть свою истинную природу " +
                      "или намерения. Когда заклинание или магический эффект пытается прочитать ваш разум, " +
                      "определить лжете ли вы, или выявить ваше мировоззрение, вы можете совершить проверку " +
                      "Обмана с КС заклинания или эффекта. В случае успеха, эффект ничего не выявит.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region DiplomacySkillFeats

                  new DBFeat
                  {
                      Name = "Bargain hunter",
                      RussianName = "Искатель выгодных сделок",
                      Description = "Вы можете выполнять Заработок денег используя Дипломатию, тратя " +
                      "свое время на поиски выгодных сделок и перепродавая их с прибылью. Вы также " +
                      "можете потратить время, специально вынюхивая отличную сделку по предмету; это " +
                      "работает так, как если бы вы использовали Заработок денег с Дипломатией, за " +
                      "исключением того, что вместо получения денег вы покупаете предмет со скидкой, " +
                      "равной деньгам, которые вы бы получили, или получая его бесплатно, если ваш " +
                      "полученный доход больше или равен стоимость предмета. И наконец, если вы " +
                      "выбираете Искатель выгодных сделок при создании персонажа на 1-м уровне, то " +
                      "начинаете игру с дополнительными 2 зм.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Group impression",
                      RussianName = "Впечатлить группу",
                      Description = "Когда вы используете Произвести впечатление, то можете сравнить " +
                      "свой результат проверки Дипломатии с КС Воли 2 целей, вместо 1. Возможно получить " +
                      "разную степень успешности для каждой цели. Количество целей увеличивается до 4 " +
                      "если вы эксперт, 10 если мастер и 25 если легенда.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Hobnobber",
                      RussianName = "Общительный",
                      Description = "Вы умело выведываете информацию в разговоре. Активность " +
                      "исследования Собрать информацию занимает у вас половину обычного времени " +
                      "(обычно сокращая время до 1 часа). Если вы мастер Дипломатии и используете " +
                      "Сбор информации с нормальной скоростью, и при броске проверки получаете " +
                      "критический провал, то вместо этого получаете просто провал. Все еще нет " +
                      "гарантии, что слухи, которые вы узнали Сбором информации, являются точными.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Glad-hand",
                      RussianName = "Радушный прием",
                      Description = "Первое впечатление - ваша сильная сторона. Когда вы встречаете " +
                      "кого-то в повседневной или светской ситуации, вы можете мгновенно совершить " +
                      "проверку Дипломатии, чтобы Произвести впечатление на это существо, без " +
                      "необходимости разговаривать с ним 1 минуту. Вы получаете к проверке штраф -5. " +
                      "Если вы проваливаете или крит.проваливаете, то вы можете начать 1-минутную беседу, " +
                      "и по окончании этого времени предпринять новую проверку, вместо принятия " +
                      "результата провала или крит.провала.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Shameless request",
                      RussianName = "Наглая просьба",
                      Description = "Используя абсолютную наглость и очарование вы можете сгладить " +
                      "последствия или возмутительность своих просьб. Когда вы Просите о чем-то, то " +
                      "снижаете любые повышения КС за возмутительные просьбы на 2, и если при броске " +
                      "получаете критический провал, то вместо этого получаете простой провал. Хотя " +
                      "это и означает, что вы этими Просьбами никогда не сможете заставить свою цель " +
                      "снизить к вам свое отношение, но они в конечном итоге устают от этого, даже если " +
                      "все еще положительно относятся.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary negotiation",
                      RussianName = "Легендарные переговоры",
                      Description = "Вы можете вести переговоры невероятно быстро в неблагоприятных " +
                      "ситуациях. Вы совершаете Произвести впечатление, а затем Просите своего " +
                      "оппонента прекратить его текущую деятельность и вступить в переговоры. Вы " +
                      "получаете штраф -5 к вашей проверке Дипломатии. Мастер устанавливает КС для " +
                      "Просьбы в зависимости от обстоятельств, обычно это как минимум очень сложный " +
                      "КС на основе уровня существа. Некоторые существа могут просто отказаться, а " +
                      "даже те, кто согласится на переговоры, могут в конечном счете счесть ваши " +
                      "аргументы недостаточными и вернуться к насилию.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region IntimidationSkillFeats

                  new DBFeat
                  {
                      Name = "Group coercion",
                      RussianName = "Групповое принуждение",
                      Description = "Когда вы используете Принуждение, то можете сравнить свой " +
                      "результат проверки Запугивания с КС Воли 2 целей, вместо 1. Возможно получить " +
                      "разную степень успешности для каждой цели. Количество целей на которые вы можете " +
                      "применить Принуждение за одиночное действие увеличивается до 4 если вы " +
                      "эксперт, 10 если мастер и 25 если легенда.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Intimidating glare",
                      RussianName = "Запугивающий взгляд",
                      Description = "Вы можете Деморализовать всего лишь взглядом. Когда вы так " +
                      "делаете, действие Деморализовать теряет признак слуховой и получает " +
                      "визуальный, и вы не получаете штраф, если существо не понимает ваш язык.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Intimidating prowess",
                      RussianName = "Выдающееся запугивание",
                      Description = "В ситуациях, когда вы можете физически угрожать цели во время " +
                      "использования Принуждение или Деморализовать, вы получаете к своим проверкам " +
                      "Запугивания бонус обстоятельства +1 и игнорируете штраф за отсутствие общего " +
                      "языка. Если ваше значение Силы 20 или больше, и вы мастер Запугивания, то этот " +
                      "бонус увеличивается до +2.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Lasting coercion",
                      RussianName = "Длительное принуждение",
                      Description = "Когда вы успешно используете Принуждение на кого-то, то " +
                      "максимальное время подчинения увеличивается до недели, но все еще " +
                      "определяется Мастером. Если вы легенда Запугивания, максимальное время " +
                      "увеличивается до месяца.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Battle cry",
                      RussianName = "Боевой клич",
                      Description = "Когда вы кидаете инициативу, то свободным действием " +
                      "можете прокричать могучий боевой клич и Деморализовать замеченного врага. " +
                      "Если вы легенда Запугивания, то можете использовать реакцию, чтобы " +
                      "Деморализовать своего врага, когда совершаете критически успешный бросок атаки.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Terrified retreat",
                      RussianName = "Отступление в ужасе",
                      Description = "Когда вы получаете критический успех действия Деморализовать, " +
                      "если уровень цели меньше вашего, то цель получает состояние бегство на 1 раунд.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Scare to death",
                      RussianName = "Напугать до смерти",
                      Description = "Вы можете так сильно напугать врагов, что они умрут. " +
                      "Совершите проверку Запугивания с КС Воли живого существа в пределах 30 футов " +
                      "от вас, которое вы можете чувствовать или видеть, и которое может чувствовать " +
                      "или видеть вас. Если цель не может слышать вас или не понимает языка на котором " +
                      "вы говорите, то вы получаете штраф обстоятельства -4. Существо временно иммунно " +
                      "на 1 минуту. Критический успех: Цель должна совершить спасбросок Стойкости с " +
                      "вашим КС Запугивания. При критическом провале, она умирает. При любом другом " +
                      "результате она становится напугана 2, и впадает в бегство на 1 раунд. Эффект " +
                      "крит.провала обладает признаком смерть. Успех: Цель получает состояние напуган 2." +
                      "Провал: Цель получает состояние напуган 1. Критический провал: Цель невредима.",
                      Level = 15,
                      Traits = new List<FeatTraits>
                      {
                            FeatTraits.Incapacitation,
                            FeatTraits.Fear,
                            FeatTraits.Emotion
                      },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region LoreSkillFeats

                  new DBFeat
                  {
                      Name = "Experienced professional",
                      RussianName = "Опытный профессионал",
                      Description = "Вы осторожны в своих профессиональных действиях, чтобы не " +
                      "допустить кромешного провала. Когда вы используете Знания для Заработок денег, " +
                      "и если при броске получаете крит.провал, то вместо этого получаете просто " +
                      "провал. Если вы эксперт Знаний, то получаете в 2 раза больше дохода от " +
                      "проваленной проверки Заработок денег, если только она не была изначально " +
                      "крит.провалом.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Unmistakable lore",
                      RussianName = "Безошибочные знания",
                      Description = "Вы никогда не ошибаетесь в тех сферах знаний, в которых разбираетесь. " +
                      "Когда вы применяете Вспомнить информацию используя любой подраздел Знаний " +
                      "которому обучены, и при броске получаете крит.провал, то вместо этого " +
                      "получаете обычный провал. Если вы мастер подраздела Знаний, то при крит.успехе, " +
                      "вы получаете еще больше информации или контекста чем обычно.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary professional",
                      RussianName = "Легендарный профессионал",
                      Description = "Ваша слава распространилась по земле (например, если у вас есть " +
                      "Знания военного дела, вы можете быть легендарным генералом или тактиком). " +
                      "Это работает так же как Легендарный исполнитель, за исключением того, что вы " +
                      "получаете работы более высокого уровня, когда пытаетесь Заработок денег с помощью " +
                      "Знаний.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region MedicineSkillFeats

                  new DBFeat
                  {
                      Name = "Battle medicine",
                      RussianName = "Боевая медицина",
                      Description = "Вы можете подлатать раны даже в бою. Совершите проверку Медицины " +
                      "с таким же КС как для Лечение ран и восстановите соответствующее количество ОЗ; " +
                      "это не убирает состояние ранен. Как и для Лечение ран, вы можете выполнить " +
                      "проверку с более высоким КС, если у вас есть минимальный уровень мастерства. " +
                      "После этого, цель временно иммунна к вашей Боевой медицине на 1 день.",
                      Level = 1,
                      Traits = new List<FeatTraits>
                      {
                          FeatTraits.Healing,
                          FeatTraits.Manipulate,
                      },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Continual recovery",
                      RussianName = "Непрерывное выздоровление",
                      Description = "Вы фанатично следите за выздоровлением пациента, чтобы ускорить " +
                      "лечение. Когда вы используете Лечение ран, ваш пациент становится иммунным " +
                      "только на 10 минут вместо 1 часа. Это применяется только к вашим активностям " +
                      "Лечение ран, а не к другим, которые получает пациент.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Robust recovery",
                      RussianName = "Надежное выздоровление",
                      Description = "Вы изучали народную медицину, чтобы помочь оправиться от болезней " +
                      "и яда, и ее усердное использование сделало вас особенно выносливым. Когда вы " +
                      "используете Лечение болезни или Лечение от яда, или кто-то другой использует " +
                      "одно из этих действий на вас, увеличьте бонус обстоятельства при успехе до +4, " +
                      "и если результат спасброска пациента является успехом, то вместо этого он " +
                      "получает крит.успех.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Ward medic",
                      RussianName = "Врач отделения",
                      Description = "Вы учились в больших медицинских палатах, где лечили сразу " +
                      "нескольких пациентов и заботились обо всех их нуждах. Когда вы используете " +
                      "Лечение болезни или Лечение ран, то можете лечить сразу вплоть до 2 целей. " +
                      "Если вы мастер Медицины, то можете лечить вплоть до 4 целей, а если вы легенда, " +
                      "то можете лечить вплоть до 8 целей.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary medic",
                      RussianName = "Легендарный врач",
                      Description = "Вы совершили медицинские открытия или придумали методы, которые " +
                      "достигают чудесных результатов. Раз в день для каждой цели, вы можете потратить " +
                      "1 час на лечение и совершить проверку Медицины, чтобы убрать болезнь или " +
                      "состояние слепота, глухота, обречен или истощен. Используйте КС болезни, " +
                      "заклинания или эффекта, который вызвал это состояние. Если источником эффекта " +
                      "является артефакт, выше 20-го уровня, или подобной силы, то увеличьте КС на 10.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region NatureSkillFeats

                  new DBFeat
                  {
                      Name = "Natural medicine",
                      RussianName = "Природная медицина",
                      Description = "Вы можете применять природные лекарства для исцеления своих " +
                      "союзников. Вы можете использовать Природу вместо Медицины для Лечение ран. " +
                      "На усмотрение Мастера, если вы находитесь в дикой местности, у вас может " +
                      "быть легкий доступ к свежим ингредиентам, что позволяет вам получить бонус " +
                      "обстоятельства +2 к вашей проверке Лечение ран, используя Природу.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Train animal",
                      RussianName = "Обучение животного",
                      Description = "Вы тратите время, обучая животное выполнять определенное действие. " +
                      "Вы можете либо выбрать простое действие, которое животное уже знает как выполнять " +
                      "(обычно те, что указаны в Команда животному) или попытаться научить животное " +
                      "новому простому действию. Мастер определяет КС любой требуемой проверки и " +
                      "количество времени на обучение (обычно минимум 1 неделю). Обычно невозможно " +
                      "научить животное трюку, который использует критическое мышление. Если вы " +
                      "эксперт, мастер или легенда Природы, то на усмотрение Мастера можете суметь " +
                      "обучать диковинных существ. Успех: Животное обучается действию.Если это было " +
                      "действие, которое животное уже знало, вы можете Скомандовать животному " +
                      "исполнить его, без совершения проверки Природы.Если это было новое стандартное " +
                      "действие, добавьте его к списку действий, которые животное может выполнить " +
                      "по Команде, но вы все еще должны совершать бросок. Провал: Животное не обучается " +
                      "новому трюку",
                      Level = 1,
                      Traits = new List<FeatTraits>
                      {
                            FeatTraits.Manipulate,
                            FeatTraits.Downtime
                      },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Bonded animal",
                      RussianName = "Прирученное животное",
                      Description = "Вы устанавливаете прочные связи с животными. Вы можете потратить " +
                      "7 дней отдыха, постоянно взаимодействуя с нормальным животным (не компаньоном " +
                      "или другим особым животным), которое к вам дружественно или любезно. По окончанию " +
                      "этого периода выполните проверку Природы с КС 20. При успехе, вы приручаете " +
                      "животное. Оно становится постоянно любезно с вами, если только вы не сделаете " +
                      "что-то вопиющее, чтобы нарушить эту связь. Любезным животным проще командовать, " +
                      "как описано в действии Команда животному. Связь с новым животным прекращает любую " +
                      "предыдущую связь, которая у вас была.У вас не может быть одновременно прирученное " +
                      "животное и зверь - компаньон(однако, вы можете иметь прирученное животное и " +
                      "фамильяра).",
                      Level = 2,
                      Traits = new List<FeatTraits>
                      {
                            FeatTraits.Downtime
                      },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region OccultismSkillFeats

                  new DBFeat
                  {
                      Name = "Oddity identification",
                      RussianName = "Определение странностей",
                      Description = "У вас есть чутье на заклинания, которые обманывают разум или " +
                      "раскрывают секреты. Вы получаете бонус обстоятельства +2 к проверкам Оккультизма " +
                      "для Идентификация магии с признаками ментальный, одержимость, предсказание или " +
                      "видение.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Bizarre magic",
                      RussianName = "Странная магия",
                      Description = "Вы можете странным образом варьировать свое колдовство, независимо " +
                      "от того, можете ли вы сотворять оккультные заклинания. КС для Распознание " +
                      "заклинания, сотворяемых вами, и Идентификации используемой вами магии " +
                      "увеличиваются на 5.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region PerformanceSkillFeats

                  new DBFeat
                  {
                      Name = "Fascinating performance",
                      RussianName = "Завораживающее выступление",
                      Description = "Когда вы Выступаете, сравните свой результат с КС Воли одного " +
                      "наблюдателя. В случае успеха, цель заворожена вами на 1 раунд. Если наблюдатель " +
                      "находится в ситуации, требующей немедленного внимания, например в бою, то, " +
                      "чтобы заворожить его, вам надо получить при проверке критический успех и " +
                      "Выступление получает признак недееспособность. Вы должны выбрать какое существо " +
                      "пытаетесь заворожить до того как совершите бросок проверки, и после этого цель " +
                      "временно иммунна на 1 час. Если вы эксперт Выступления, вы можете заворожить " +
                      "вплоть до 4 наблюдателей; если мастер -вплоть до 10 наблюдателей; а если " +
                      "легенда - любое количество наблюдателей одновременно.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Impressive performance",
                      RussianName = "Впечатляющее выступление",
                      Description = "Ваши выступления вызывают восхищение и завоевывают поклонников. " +
                      "Вы можете Произвести впечатление используя Выступление вместо Дипломатии.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Virtuosic performer",
                      RussianName = "Виртуозный исполнитель",
                      Description = "У вас есть исключительный талант с одним типом выступления. " +
                      "Вы получаете бонус обстоятельства +1 при выполнении определенного вида " +
                      "выступления. Если вы мастер Выступления, этот бонус увеличивается до +2. " +
                      "Выберите 1 из следующих специализаций и применяйте бонус к проверкам этого " +
                      "вида Выступления. Если не ясно, применяется ли специализация, решает Мастер.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary performer",
                      RussianName = "Легендарный исполнитель",
                      Description = "Ваша слава распространилась по всюду. Неигровые персонажи, " +
                      "которые успешно прошли проверку Вспомнить информацию используя Общество с " +
                      "КС 10, слышали о вас и обычно относятся к вам на одну ступень лучше, чем " +
                      "обычно, в зависимости от вашей репутации и расположения неигрового персонажа. " +
                      "Например, если вы хорошо известны своим жестоким и взыскательным поведением, " +
                      "то существа могут быть напуганы вами, а не дружелюбны к вам. Когда вы выполняете " +
                      "Заработок денег с помощью Выступления, то привлекаете аудиторию более высокого " +
                      "уровня чем позволяет ваша локация, поскольку аудитория собирается, чтобы " +
                      "увидеть вас. Например, правители и ангелы могут отправиться в вашу маленькую " +
                      "башню в лесу, чтобы послушать ваше выступление. Обычно, на усмотрение Мастера, " +
                      "это увеличивает доступную аудиторию на 2 или более уровня.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region ReligionSkillFeats

                  new DBFeat
                  {
                      Name = "Student of the canon",
                      RussianName = "Ученик канона",
                      Description = "Вы изучили достаточно много верований, чтобы узнавать о них признаки, " +
                      "которые вряд ли верны. Если при броске проверки Религии для Расшифровка текста " +
                      "религиозного происхождения, или Вспомнить информацию о принципах веры вы получили " +
                      "крит.провал, то вместо этого получаете просто провал. Когда выполняете Вспомнить " +
                      "информацию о принципах своей веры и при броске получаете провал, то вместо этого " +
                      "получаете успех, а если при броске получаете успех, то вместо этого получаете " +
                      "крит.успех.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Divine guidance",
                      RussianName = "Божественное наставление",
                      Description = "Вы настолько погружены в божественное писание, что находите смысл " +
                      "и наставления в своих текстах в любой ситуации. Потратьте 10 минут на Расшифровка " +
                      "текста религиозного значения вашего божества или философии, думая о конкретной " +
                      "проблеме или дилемме, стоящей перед вами и совершите проверку Религии (КС " +
                      "определяется Мастером). В случае успеха вы обнаруживаете соответствующий стих, " +
                      "притчу или афоризм, которые могут помочь вам двигаться вперед или изменить образ " +
                      "мышления, чтобы помочь решить вашу головоломку. Например, Мастер может предоставить " +
                      "вам загадочный стих или подсказку, которая поможет вам перейти к следующему шагу " +
                      "решения вашей проблемы.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region SocietySkillFeats

                  new DBFeat
                  {
                      Name = "Courtly graces",
                      RussianName = "Аристократическое изящество",
                      Description = "Вы были воспитаны среди знати или научились правильному этикету и " +
                      "поведению, что позволяет вам представлять себя как дворянина и играть в " +
                      "политические игры и бороться за влияние. Вы можете использовать Общество, " +
                      "чтобы Произвести впечатление на знать, а также, чтобы Перевоплотиться и " +
                      "претвориться знатью, если вы таковым не являетесь. Если вы хотите притвориться " +
                      "каким-то определенным представителем знати, то вам все еще надо использовать " +
                      "Обманом, чтобы Перевоплотиться и Лгать когда это потребуется.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Multilingual",
                      RussianName = "Многоязычный",
                      Description = "Вы легко изучаете новые языки. Вы изучаете 2 новых языка, " +
                      "выбираемых из распространенных, необычных и любых других языков, к которым у вас " +
                      "есть доступ. Вы изучаете дополнительный язык, если являетесь или становитесь " +
                      "мастером Общества, и снова, если вы являетесь или становитесь легендой. " +
                      "Особенность: Вы можете выбрать эту способность несколько раз. Каждый раз вы " +
                      "изучаете новые языки.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Read lips",
                      RussianName = "Чтение по губам",
                      Description = "Вы можете читать по губам тех, кто поблизости, и кого вы можете " +
                      "ясно видеть. В обычное время вы можете делать это автоматически. В режиме " +
                      "столкновения или когда пытаетесь осуществить более сложное чтение по губам, " +
                      "вы получаете состояние заворожен и застигнут врасплох во время каждого раунда " +
                      "в котором вы сосредотачиваетесь на чтении губ, и для успешного чтения по губам " +
                      "вы должны выполнить проверку Общества (КС определяется Мастером). В любом случае, " +
                      "вы должны знать тот язык на котором разговаривают.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Sign language",
                      RussianName = "Язык жестов",
                      Description = "Вы изучаете языки жестов относящиеся ко всем известных вам языкам, " +
                      "что позволяет вам использовать жесты и понимать их. Как правило, чтобы передавать " +
                      "более сложные понятия, языки жестов требуют обеих рук, и они имеют признак " +
                      "визуальный, а не слуховой. Язык жестов трудно понимать во время боя из - за того, " +
                      "сколько внимания это требует, в отличие от основных жестов, таких как указание " +
                      "на врага, чтобы предложить цель.Язык жестов трудно использовать в местах с плохой " +
                      "видимостью, так же как речь трудно использовать в шумной обстановке.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Streetwise",
                      RussianName = "Уличная жизнь",
                      Description = "Вы знаете о жизни на улицах и чувствуете пульс вашего местного " +
                      "поселения. Вы можете использовать свой модификатор Общества вместо Дипломатии, " +
                      "чтобы Собрать информацию. В любом населенном пункте, где вы регулярно бываете, " +
                      "вы можете использовать действие Вспомнить информацию с Обществом, чтобы узнать " +
                      "ту же информацию, которую вы можете узнать с Дипломатией и Собрать информацию. " +
                      "Обычно, КС для этого значительно выше, но вы узнаете информацию не тратя время " +
                      "на ее сбор. Если вы проваливаете сбор информации, то все еще можете впоследствии " +
                      "попытаться Собрать информацию обычным способом.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Connections",
                      RussianName = "Связи",
                      Description = "У вас есть социальные связи, которые вы можете использовать для " +
                      "обмена услугами или встречи с важными людьми. Когда вы находитесь в районе со " +
                      "связями (как правило, в поселении, где вы потратили время на создание связей, " +
                      "или, возможно, в другом районе той же страны), вы можете совершить проверку " +
                      "Общества, чтобы устроить встречу с важной политической фигурой или попросить их " +
                      "об услуге в обмен на другую услугу позднее, по выбору вашего контакта. Мастер " +
                      "выбирает КС на основе сложности услуги и известности личности.",
                      Level = 1,
                      Traits = new List<FeatTraits>
                      {
                            FeatTraits.Uncommon
                      },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary codebreaker",
                      RussianName = "Легендарный шифровальщик",
                      Description = "Ваши навыки языков и работы с кодами настолько велики, что вы " +
                      "можете расшифровывать информацию с помощью всего лишь беглого чтения текста. " +
                      "Вы можете выполнять Расшифровка текста используя Общество во время чтения с " +
                      "нормальной скоростью. Если вы замедлитесь и потратите полное время, которое " +
                      "обычно требуется для этого, и при броске получаете успех, то вместо этого " +
                      "получаете критический успех; если вы получаете критический успех читая с " +
                      "обычной скоростью, то получаете почти дословное понимание документа.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary linguist",
                      RussianName = "Легендарный лингвист",
                      Description = "Вы настолько искусны в языках, что можете мгновенно создать пиджин. " +
                      "Вы всегда можете поговорить с любым существом, которое общается на языке, даже " +
                      "том который вы не знаете, создав новый язык пиджин, использующий упрощенные " +
                      "термины и передающий основные понятия. Чтобы сделать это, вы должны сначала " +
                      "понять, по крайней мере, какое средство коммуникации использует существо (речь, " +
                      "язык жестов и т.д.).",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region StealthSkillFeats

                  new DBFeat
                  {
                      Name = "Experienced smuggler",
                      RussianName = "Опытный контрабандист",
                      Description = "Вы часто провозите вещи контрабандой мимо властей. Когда Мастер " +
                      "совершает за вас бросок тайной проверки Скрытности, чтобы узнать заметили ли " +
                      "пассивные наблюдатели скрытый вами маленький предмет, то в качестве результата " +
                      "вашего броска кости он использует число на кости или 10, в зависимости от того " +
                      "что больше, добавляя его к вашему модификатору Скрытности, для определения " +
                      "результат проверки Скрытности. Если вы мастер Скрытности, то Мастер использует " +
                      "число от броска кости или 15, а если вы легенда Скрытности, то получаете " +
                      "автоматический успех прячя маленький предмет от пассивных наблюдателей. " +
                      "Это не дает преимуществ, когда существо совершает проверку Восприятия активно " +
                      "обыскивая вас на скрытые предметы. Из-за своего навыка контрабандиста, вы, " +
                      "скорее всего, найдете более прибыльную работу связанную с контрабандой, когда " +
                      "используете Знания преступного мира для Заработок денег.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Terrain stalker",
                      RussianName = "Лазутчик местности",
                      Description = "Выберите 1 из следующих видов сложной местности: обломки/щебень," +
                      "снег, подлесок. Когда на этом виде местности вы необнаружены всеми не-союзниками, " +
                      "то можете Красться без совершения проверки Скрытности, пока вы двигаетесь не " +
                      "более 5 футов за раз, и в любой момент во время движения не двигаетесь в пределах " +
                      "10 футов от врага.Еще это позволяет вам автоматически приближаться к существам на " +
                      "расстояние вплоть до 15 футов при использовании Избегать обнаружения во время " +
                      "исследования, до тех пор, пока они не Ищут активно или находятся на чеку. " +
                      "Особенность: Вы можете выбрать эту способность несколько раз. Каждый раз " +
                      "выбирайте другой вид сложной местности.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Quiet allies",
                      RussianName = "Тихие союзники",
                      Description = "Вы умеете передвигаться с группой. Когда вы используете Избегать " +
                      "обнаружения а ваши союзники Повторять за экспертом, вы с этими союзниками " +
                      "можете совершить бросок одной проверки Скрытности, используя наименьший " +
                      "модификатор, вместо совершения отдельных бросков. Это не применяется к броскам " +
                      "инициативы.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Foil senses",
                      RussianName = "Одурачить чувства",
                      Description = "Вы искусны в обмане особых чувств существ и достаточно осторожны, " +
                      "чтобы в любой момент предостеречься от них. Всякий раз, когда вы используете " +
                      "Избегать обнаружения, Спрятаться или Красться, то считается, что вы всегда " +
                      "принимаете меры предосторожности против особых чувств.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Swift sneak",
                      RussianName = "Быстро красться",
                      Description = "Вы можете Красться с полной Скоростью. Вы можете Быстро красться, " +
                      "когда Роете, Карабкаетесь, Летите или Плывете вместо Перемещения, если у вас есть " +
                      "соответствующий вид движения.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary sneak",
                      RussianName = "Легендарно красться",
                      Description = "Вы всегда крадетесь, даже когда негде спрятаться, если только вы " +
                      "сами не выбрали быть видимым. Вы можете Спрятаться и Красться даже без укрытия " +
                      "или не будучи скрытым. Когда вы используете тактику исследования отличную от " +
                      "Избегать обнаружения, то вы еще получаете преимущества Избегать обнаружения, если " +
                      "только явно не решите не делать этого. ",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region SurvivalSkillFeats

                  new DBFeat
                  {
                      Name = "Experienced tracker",
                      RussianName = "Опытный следопыт",
                      Description = "Выслеживание - ваша вторая натура, и при необходимости вы можете " +
                      "идти по следу без перерыва. Вы можете выполнять Выслеживание двигаясь с полной " +
                      "Скоростью, но получая штраф -5 к своей проверке Выживания. Если вы мастер " +
                      "Выживания, то не получаете штраф -5. Если вы легенда Выживания, то при " +
                      "выслеживании вам не надо каждый час делать новый бросок проверки Выживания, " +
                      "однако все еще надо совершать новый бросок при значительном изменении следа.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Forager",
                      RussianName = "Добытчик еды",
                      Description = "Если при использовании Выживание для Проживания, вы при броске " +
                      "получаете результат хуже успеха, то вместо этого получаете успех. При успехе, " +
                      "вы можете обеспечить прожиточный минимум для себя и 4 дополнительных существ, " +
                      "при крит.успехе вы можете позаботиться о в 2 раза большем количестве существ, " +
                      "чем при успехе. Каждый раз, когда ваш уровень мастерства в Выживании увеличивается, " +
                      "удвойте количество дополнительных существ о которых вы можете позаботиться при " +
                      "успехе(до 8 если эксперт, 16 если мастер, или 32 если легенда).Вы можете решить " +
                      "позаботиться о в два раза меньшем количестве дополнительных существ и вместо " +
                      "минимальных условий обеспечить комфортные. Несколько существ меньшего размера " +
                      "или существ со значительно меньшими аппетитами, чем у человека, считаются для " +
                      "этой способности 1 существом, а каждое более крупное существо или существа со " +
                      "значительно большими аппетитами считаются несколькими существами. Мастер " +
                      "определяет сколько требуется пищи существам не людям.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Survey wildlife",
                      RussianName = "Изучение дикой природы",
                      Description = "Вы можете исследовать подробности дикой природы, чтобы определить " +
                      "присутствие существ поблизости. Вы можете потратить 10 минут на оценку окружающей " +
                      "области, чтобы выяснить какие есть поблизости существа, на основе гнезд, " +
                      "экскрементов и отметок на растительности. Выполните проверку Выживания с КС " +
                      "определенным Мастером, в зависимости от того, насколько очевидны эти признаки. " +
                      "При успехе, вы можете совершить проверку Вспомнить информацию со штрафом -2, " +
                      "чтобы узнать больше о существах, только по этим признакам. Если вы мастер " +
                      "Выживания, то не получаете этот штраф.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Terrain expertise",
                      RussianName = "Опыт местности",
                      Description = "Ваш опыт ориентирования в определенном типе местности, делает вас " +
                      "чрезвычайно уверенным в своих силах. Вы получаете бонус обстоятельства +1 к " +
                      "проверкам Выживания в одном из следующих видов местности, который вы выбираете " +
                      "вместе со способностью: Водная, Арктика, Пустыня, Лес, Горы, Равнины, Небо, " +
                      "Болото, Подземелье.Особенность: Вы можете выбрать эту способность более одного " +
                      "раза, каждый раз выбирая другой вид местности.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Planar survival",
                      RussianName = "Планарное выживание",
                      Description = "Вы можете использовать Выживание для Проживание на других планах, " +
                      "даже тех, где нет ресурсов или природных явлений, которые вам обычно нужны. " +
                      "Например, вы можете добывать пищу, даже если на этом плане не хватает пищи, " +
                      "которой вы бы могли нормально подкрепиться. На усмотрение Мастера, успех вашей " +
                      "проверки Проживание может еще снизить урон наносимым планом.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary survivalist",
                      RussianName = "Легендарный выживальщик",
                      Description = "Вы можете неопределенно долго выживать без пищи и воды, а также " +
                      "переносить сильные, экстремальные и невероятные холод и жару, не получая при этом " +
                      "никакого урона.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #region ThieverySkillFeats

                  new DBFeat
                  {
                      Name = "Pickpocket",
                      RussianName = "Карманник",
                      Description = "Вы можете Украсть объект или использовать на него Ловкость рук, " +
                      "если он тщательно охраняется, как например в кошельке, не получая штраф -5. " +
                      "Вы не можете красть объекты, которые будет чрезвычайно заметно или трудозатратно " +
                      "снять (такие как надетая обувь, доспех, или объекты которыми активно владеют). " +
                      "Если вы мастер Воровства, то можете попытаться Украсть у существа, которое " +
                      "находится в бою или на чеку. Когда вы так делаете, Украсть требует 2 действия " +
                      "с признаком воздействие вместо 1 действия, и вы получаете штраф -5.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Subtle theft",
                      RussianName = "Незаметное воровство",
                      Description = "Когда вы успешно что-то Крадете, наблюдатели (существа, не " +
                      "являющиеся тем, у кого вы украли) получают штраф обстоятельства -2 к их КС " +
                      "Восприятия для обнаружения кражи. Дополнительно,если вы сначала используете Обман, " +
                      "чтобы Отвлечь внимание, применение к объекту одиночного действия Украсть или " +
                      "Ловкость рук не прерывает ваше состояние необнаружен.",
                      Level = 1,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Wary disarmament",
                      RussianName = "Осторожное отключение",
                      Description = "Если провоцируете активацию устройства или ловушки во время их " +
                      "отключения, то получаете бонус обстоятельства +2 к КБ или спасброску против этого " +
                      "устройства или ловушки. Это применяется только к атакам или эффектам вызванным " +
                      "провалом вашей попытки, а не к более поздним, таким как дополнительные атаки от " +
                      "комплексных ловушек.",
                      Level = 2,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Quick unlock",
                      RussianName = "Быстрое вскрытие",
                      Description = "Вы можете выполнять Вскрытие замка используя 1 действие, вместо " +
                      "2 действий.",
                      Level = 7,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },
                  new DBFeat
                  {
                      Name = "Legendary thief",
                      RussianName = "Легендарный вор",
                      Description = "Ваше умение Украсть превосходит ожидания. Вы можете попытаться " +
                      "Украсть что-то, чем активно владеют, или было бы чрезвычайно заметно или " +
                      "затратно по времени, чтобы снять (как надетая обувь или доспех). Вы должны делать " +
                      "это медленно и осторожно, тратя не менее 1 минуты (и значительно дольше для " +
                      "предметов, на снятие которых обычно требуют много времени, таких как доспехи). " +
                      "На протяжении всего этого времени у вас должны быть возможности оставаться " +
                      "спрятанным, как, например, покров темноты или шумная толпа. Вы получаете штраф " +
                      "-5 к проверке Воровства. Даже если у вас получится, и предмет очень заметен, как " +
                      "полный латный доспех, то очевидцы быстро обратят внимание на то, что он исчез " +
                      "после того, как вы его украли.",
                      Level = 15,
                      Traits = new List<FeatTraits> { },
                      Type = FeatType.Skill,
                  },

            #endregion

            #endregion

            #region AncestryFeats

            #region HumanAncestryFeats

            #region Level1

            new DBFeat
            {
                Name = "Adapted cantrip",
                RussianName = "Заимствованные чары",
                Description = "Изучая множество магических обычаев, вы изменили заклинание в " +
                "соответствии со своим стилем колдовства. Выберите одни чары не из вашего колдовского " +
                "обычая. Если у вас есть репертуар заклинаний или книга заклинаний, замените одни из " +
                "чар, которые вы знаете или храните в книге, на выбранные чары. Если вы подготавливаете " +
                "заклинания без книги заклинаний (например, если вы жрец или друид), одни из ваших чар " +
                "всегда должны быть выбранными для этой способности, а остальные вы подготавливаете " +
                "как обычно. Вы можете сотворять эти чары как заклинание магического обычая своего " +
                "класса. Если вы позже меняете или перетренируете эти чары, то можете выбрать замену " +
                "из этого же магического обычая или из другого.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Cooperative nature",
                RussianName = "Коллективный характер",
                Description = "Короткая человеческая жизнь дает другие взгляды и научила вас с юных " +
                "лет пренебрегать различиями и работать с другими для того, чтобы преуспевать. Вы " +
                "получаете бонус обстоятельства +4 к проверкам действия Помощь.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "General training",
                RussianName = "Общая тренировка",
                Description = "Ваша адаптируемость проявляется в овладении целым рядом полезных умений. " +
                "Вы получаете общую способность 1-го уровня. Вы должны соответствовать предварительным " +
                "условиям способности, но если вы выбираете эту способность во время создания персонажа, " +
                "то можете отложить ее выбор на более поздние стадии создания, чтобы определить по каким " +
                "предварительным условиям вы подходите. Особенность: Вы можете выбрать эту способность " +
                "много раз, каждый раз выбирая другую способность.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Haughty obstinacy",
                RussianName = "Надменное высокомерие",
                Description = "Ваше сильное эго мешает другим помыкать вами. Если при броске против " +
                "ментального эффекта, который пытается взять ваши действия под прямое управление, " +
                "вы получаете успех спасброска, то вместо этого получаете критический успех. Если " +
                "существо при броске проваливает проверку Принуждения, используя Запугивание, то " +
                "вместо этого оно получает критический провал (и не может снова использовать на вас " +
                "Принуждение 1 неделю).",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Natural ambition",
                RussianName = "Природные амбиции",
                Description = "Вы росли амбициозным и тянулись к звездам, что приводит вас к быстрому " +
                "прогрессу в выбранной области. Вы получаете способность своего класса 1-го уровня. " +
                "Вы должны соответствовать предварительным условиям способности, но если вы выбираете " +
                "эту способность во время создания персонажа, то можете отложить ее выбор на более " +
                "поздние стадии создания, чтобы определить по каким предварительным условиям вы подходите.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Natural skill",
                RussianName = "Природный навык",
                Description = "Ваша находчивость позволяет вам изучать большое разнообразие навыков. " +
                "Вы становитесь обучены двум навыкам на свой выбор.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Unconventional weaponry",
                RussianName = "Необычное оружие",
                Description = "Вы знакомы с определенным оружием, возможно принадлежащим другой " +
                "родословной или культуре. Выберите необычное простое или воинское оружие, с " +
                "признаком, соответствующим родословной (дварф, гоблин, орк, и т.п.) или " +
                "распространенным в другой культуре. Вы получаете доступ к этому оружию, а с целью " +
                "определения вашего мастерства обращения с ним, это оружие считается простым оружием. " +
                "Если вы обучены обращению со всем воинским оружием, то можете выбрать необычное " +
                "продвинутое оружие с таким признаком.Вы получаете доступ к этому оружию, а с целью " +
                "определения вашего мастерства обращения с ним, это оружие считается воинским оружием.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },

            #endregion

            #region Level5

            new DBFeat
            {
                Name = "Adaptive adept",
                RussianName = "Знаток заимствования",
                Description = "Вы продолжили адаптировать свою магию, чтобы смешать обычай вашего " +
                "класса с заимствованным. Выберите чары или заклинание 1-го уровня из того же " +
                "магического обычая, что и чары из способности Заимствованные чары. Вы получаете это " +
                "заклинание, добавляя его в свой репертуар заклинаний, книгу заклинаний, или " +
                "подготавливаемые заклинания, так же как и чары от способности Заимствованные чары. " +
                "Вы можете сотворять это заклинание, как заклинание магического обычая вашего класса. " +
                "Если вы выбираете заклинание 1-го уровня, то не получаете доступ к его усиленным " +
                "версиям, а значит не можете подготовить его, если вы подготавливаете заклинания, " +
                "и не можете выучить его либо, если у вас имеется репертуар заклинаний, то не можете " +
                "выбирать его коронным заклинанием.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },
            new DBFeat
            {
                Name = "Clever improviser",
                RussianName = "Смышленый импровизатор",
                Description = "Вы научились справляться с ситуациями которые вам не по зубам. Вы " +
                "получаете общую способность Импровизация без тренировки. Еще вы можете использовать " +
                "действия навыков, для которых обычно требуется быть обученным навыку, даже если вы " +
                "нетренированы.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },

            #endregion

            #endregion

            #region GoblinAncestryFeats

            #region Level1

            new DBFeat
            {
                Name = "Burn it!",
                RussianName = "Сжечь!",
                Description = "Вас завораживает огонь. Ваши заклинания и алхимические предметы, " +
                "которые наносят огненный урон, получают бонус состояния к урону, равный половине " +
                "уровня заклинания или четверти уровня предмета (минимум 1). Еще вы получаете бонус " +
                "состояния +1 к любому наносимому вами продолжительному огненному урону.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "City scavenger",
                RussianName = "Городской падальщик",
                Description = "Вы знаете, что самые большие сокровища часто выглядят как мусор, и вы " +
                "насмехаетесь над теми, кто выбрасывает идеальные объедки. Вы получаете бонус " +
                "обстоятельства +1 к проверкам Проживание, и вы можете использовать навык Общество " +
                "или Выживание когда используете Проживание в поселении. Когда используете Проживание " +
                "в городе, вы еще получаете полезный мусор, который выбрасывают глупые длинноногие. " +
                "Вы можете выполнять Заработок денег, используя Общество или Выживание, в тоже время, " +
                "когда и Проживание, не тратя никаких дополнительных дней отдыха. Еще вы получаете " +
                "бонус обстоятельства + 1 к этой проверке. Особенность: Если у вас есть наследие " +
                "Железнобрюхий гоблин, увеличьте бонусы до + 2.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Goblin lore",
                RussianName = "Гоблинские знания",
                Description = "Вы переняли навыки и истории своего сообщества гоблинов. Вы " +
                "становитесь обучены Природе и Скрытности. Если вы автоматически станете обучены " +
                "одному из этих навыков (например из-за предыстории или класса), то вместо этого " +
                "становитесь обучены навыку на свой выбор. Еще вы становитесь обучены Гоблинским Знаниям.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Goblin scuttle",
                RussianName = "Гоблинское увиливание",
                Description = "Вы получаете преимущество от перемещения вашего союзника, чтобы выбрать " +
                "себе место поудобней. Вы делаете Шаг.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Goblin song",
                RussianName = "Гоблинская песенка",
                Description = "Вы поете надоедливые гоблинские песенки, отвлекая своих врагов глупыми " +
                "и повторяющимися текстами. Сделайте проверку Выступления против КС Воли одного врага " +
                "в пределах 30 футов. Это действие имеет обычные признаки и ограничения проверки " +
                "Выступления. Вы можете воздействовать на 2 цели в пределах дистанции, если вы эксперт " +
                "Выступления, на 4 если вы мастер, и на 8 если легенда. Критический успех: Цель " +
                "получает штраф состояния - 1 к проверкам Восприятия и спасброскам Воли на 1 минуту. " +
                "Успех: Цель получает штраф состояния - 1 к проверкам Восприятия и спасброскам Воли на " +
                "1 раунд. Критический провал: Цель временно иммунна к попыткам использования Гоблинской " +
                "песенки на 1 час.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Goblin weapon familiarity",
                RussianName = "Знакомство с гоблинским оружием",
                Description = "Чужаки могут смотреть на него с презрением, но вы знаете, что оружие " +
                "вашего народа столь же эффективно, сколь и остро. Вы обучены обращению с собачим " +
                "тесаком и лошадиным тесаком. Дополнительно, вы получаете доступ ко всем необычным " +
                "оружиям гоблинов.Для определения уровня мастерства, воинское гоблинское оружие " +
                "считается простым, а продвинутое гоблинское оружие считается воинским.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Junk tinker",
                RussianName = "Изобретатель из мусора",
                Description = "Вы можете сделать полезные инструменты даже из кривого или ржавого " +
                "мусора. Когда используете навык Ремесло для Создать, то можете сделать предметы " +
                "0-го уровня из мусора, включая оружие, но не доспехи. Это снижает цену до 1/4 от " +
                "обычной, но результат всегда низкокачественный. Низкокачественные предметы обычно " +
                "дают штраф, но вы его не получаете, когда сами пользуетесь созданными вами предметами. " +
                "С целью экономии, вы так же можете применять мусор, когда Создаете любой предмет. Это " +
                "дает вам скидку на предмет, как если бы вы потратили 1 дополнительный день работы " +
                "для снижения стоимости, но предмет очевидно сделан из мусора.На усмотрение Мастера, " +
                "это может повлиять на стоимость перепродажи предмета, в зависимости от вкусов покупателя.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Rough rider",
                RussianName = "Суровый наездник",
                Description = "Вы особенно хороши в верховой езде на традиционных гоблинских ездовых " +
                "животных. Вы получаете способность Езда верхом, даже если не удовлетворяете ее " +
                "предварительным требованиям. Вы получаете бонус обстоятельства +1 к проверкам " +
                "Природы для Команда животному, такому как гоблинский пес или ездовой волк. Вы всегда " +
                "можете выбрать волка как зверя-компаньона, даже если будете выбирать зверя-компаньона " +
                "с особенностью Ездовое животное, такого как союзник-скакун чемпиона.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Very sneaky",
                RussianName = "Очень пронырливый",
                Description = "Высокие люди редко обращают внимание на тени у своих ног, и вы в полной " +
                "мере пользуетесь этим. Когда используете Красться, то можете двигаться на 5 футов " +
                "дальше, вплоть до своей полной Скорости. Дополнительно, пока вы продолжаете Красться " +
                "и преуспеваете в проверках Скрытности, вы не становитесь замечены если у вас нет " +
                "стандартного или большого укрытия и вы не скрыты по завершении действия Красться, до " +
                "тех пор, пока в конце своего хода у вас есть стандартное или большое укрытие, или вы " +
                "скрыты.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            #endregion

            #region Level5

            new DBFeat
            {
                Name = "Goblin weapon frenzy",
                RussianName = "Ярость гоблинского оружия",
                Description = "Вы знаете как владеть злобным оружием своего народа. При крит.попадании " +
                "гоблинским оружием, вы применяете эффект критической специализации оружия.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },

            #endregion

            #endregion

            #region DwarfAncestryFeats

            #region Level1

            new DBFeat
            {
                Name = "Dwarven lore",
                RussianName = "Дварфийские знания",
                Description = "Вы жадно впитывали древние истории и обычаи своих предков, богов и " +
                "народа, изучая дисциплины и приемы, передаваемые из поколения в поколение. Вы " +
                "становитесь обучены Ремеслу и Религии. Если вы будете автоматически обучены одному " +
                "из этих навыков (например, из-за вашей предыстории или класса), то вместо этого вы " +
                "обучаетесь навыку на свой выбор. Еще вы становитесь обучены Знаниям дварфов.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Dwarven weapon familiarity",
                RussianName = "Знакомство с оружием дварфов",
                Description = "Ваши родичи привили вам склонность к тяжелому оружию, и вы предпочитаете " +
                "его вместо элегантного оружия. Вы обучены обращению с боевым топором, клевцом и боевым " +
                "молотом. Вы также получаете доступ ко всему необычному дварфийскому оружию. С целью " +
                "определения уровня мастерства, воинское оружие дварфов считается простым оружием, а " +
                "продвинутое дварфийское оружие считается воинским оружием.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Rock runner",
                RussianName = "Каменный бегун",
                Description = "Ваша врожденная связь с камнем делает вас искусным в перемещении по " +
                "неровным поверхностям. Вы можете игнорировать сложную местность вызванную гравием, " +
                "и неровную землю из камня и земли. В дополнение, когда вы используете навык Акробатики, " +
                "чтобы Балансировать на узких поверхностях или неровной земле из камня или " +
                "земли, вы не застигнуты врасплох, и когда вы при броске такой проверки Акробатики " +
                "получаете успех, то вместо этого он становится крит.успехом.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Stonecunning",
                RussianName = "Хитрость каменной кладки",
                Description = "У вас есть умение замечать даже небольшие несоответствия и ремесленнические " +
                "приемы в каменной кладке вокруг вас. Вы получаете бонус обстоятельства +2 на проверки " +
                "Восприятия, чтобы заменить необычную каменную кладку. Этот бонус применяется к " +
                "проверкам обнаружения механических ловушек сделанных из камня или спрятанных в камне. " +
                "Если вы не используете действие Поиск или не ищете, Мастер все равно автоматически " +
                "бросает за вас тайную проверку, чтобы заметить необычную каменную кладку. Эта " +
                "проверка не получает бонус обстоятельства, а получает штраф обстоятельства - 2.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Unburdened iron",
                RussianName = "Необременяющее железо",
                Description = "Вы изучили приемы, впервые придуманные вашими предками во время их " +
                "древних войн, позволяющие вам удобно носить массивные комплекты доспехов. Игнорируйте " +
                "снижение вашей Скорости от любого надетого доспеха. Дополнительно, всякий раз, когда " +
                "вы получаете штраф к Скорости по другой причине (из-за состояния перегружен или " +
                "заклинания), вычтите 5 футов из штрафа. Например, состояние перегружен обычно дает " +
                "штраф -10 футов к Скорости, но вам оно дает лишь штраф -5 футов. Если ваша Скорость " +
                "получает несколько штрафов, выберите только один штраф, значение которого будет снижено.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Vengeful hatred",
                RussianName = "Мстительная ненависть",
                Description = "Ваше сердце жаждет мести тем, кто причинил зло вашему народу. Когда вы " +
                "получаете эту способность, выберите одних из родовых врагов дварфов: дроу, дуэргар, " +
                "гигант или орк. Вы получаете бонус обстоятельства +1 к урону оружием и безоружными " +
                "атаками против существ с этим признаком. Если ваша атака будет наносить больше 1 " +
                "кости урона оружия (как обычно на уровнях выше 1-го), то бонус равен количеству" +
                " костей урона оружия или безоружной атаки. В дополнение, если существо крит.успешно " +
                "атакует вас и наносит вам урон, то вы получаете свой бонус к урону против этого " +
                "существа на 1 минуту, независимо от того, имеет ли оно выбранный признак. Особенность: " +
                "Ваш Мастер может добавить подходящие признаки существ в список родовых врагов, если " +
                "ваш персонаж относится к сообществу, которое обычно сражается с другими видами врагов.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            #endregion

            #region Level5

            //действие
            new DBFeat
            {
                Name = "Boulder roll",
                RussianName = "Наезд булыжника",
                Description = "Ваше дварфийское телосложение позволяет вам толкать врагов, точно так " +
                "же, как огромный валун катится через подземную пещеру. Сделайте Шаг в квадрат с " +
                "врагом, который вашего размера или менее, а враг должен сдвинуться на незанятое место " +
                "сразу позади него. Враг должен сдвинуться даже если это ставит его под угрозу. Враг " +
                "может сделать спасбросок Стойкости против вашего КС Атлетики, чтобы остановить ваш " +
                "Шаг. Если враг совершает этот спасбросок, то он получает дробящий урон равный вашему " +
                "уровню + модификатор Силы, если только не пройдет его крит.успешно. Если враг не " +
                "может сдвинуться в свободное пространство (например, если он окружен сплошными " +
                "объектами или другими существами), то ваш Наезд булыжника не имеет эффекта.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },
            new DBFeat
            {
                Name = "Dwarven weapon cunning",
                RussianName = "Хитрость дварфийского оружия",
                Description = "Вы изучили хитрые приемы, чтобы получить лучшие эффекты от своего " +
                "дварфийского оружия. Каждый раз, когда вы крит.успешно попадаете боевым топором, " +
                "клевцом, боевым молотом или дварфийским оружием, то вы применяете эффект " +
                "критической специализации оружия.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },


            #endregion

            #endregion

            #region ElfAncestryFeats

            #region Level1

            new DBFeat
            {
                Name = "Ancestral longevity",
                RussianName = "Родовое долголетие",
                Description = "Вы накопили огромный багаж знаний в течение прожитых лет. Во время " +
                "своих ежедневных приготовлений, вы можете поразмышлять о своем жизненном опыте, чтобы " +
                "стать обученным одному навыку на свой выбор. Этот уровень мастерства остается до вашего " +
                "следующего ежедневного приготовления. Так как это мастерство временное, вы не можете " +
                "использовать его как предварительное условие для увеличения навыка или постоянного " +
                "выбора персонажа, такого как способность.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Elven lore",
                RussianName = "Эльфийские знания",
                Description = "Вы обучались традиционным эльфийским искусствам, узнавали об арканной " +
                "магии и окружающем вас мире. Вы становитесь обучены Аркане и Природе. Если вы " +
                "автоматически становитесь обученным одному из этих навыков (например, из-за предыстории " +
                "или класса), то обучаетесь другому навыку на свой выбор. Еще вы обучаетесь " +
                "Эльфийским Знаниям.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Elven weapon familiarity",
                RussianName = "Знакомство с эльфийским оружием",
                Description = "Вы предпочитаете луки и другое элегантное оружие. Вы обучены обращению " +
                "с длинными луками, композитными длинными луками, короткими луками, композитными " +
                "короткими луками, длинными мечами и рапирами. Еще вы получаете доступ ко всему " +
                "необычному эльфийскому оружию.Для определения мастерства обращения с ним, воинское " +
                "эльфийское оружие считается простым, а продвинутое эльфийское оружие считается воинским.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Forlorn",
                RussianName = "Покинутый",
                Description = "Наблюдение за тем, как ваши друзья стареют и умирают, делает вас более " +
                "угрюмым, что защищает от вредных эмоций. Вы получаете бонус обстоятельства +1 к " +
                "спасброскам против эмоциональных эффектов. Если при броске, вы получаете успех " +
                "спасброска против эмоционального эффекта, то вместо этого вы получаете крит.успех.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Nimble elf",
                RussianName = "Проворный эльф",
                Description = "Ваши движения хорошо отточены. Ваша Скорость увеличивается на 5 футов.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Otherworldly magic",
                RussianName = "Потусторонняя магия",
                Description = "Ваша эльфийская магия проявляется как простое арканное заклинание, " +
                "даже если вы формально не обучены магии. Выберите одни чары из списка арканных. Вы " +
                "можете сотворять эти чары по желанию, как врожденное арканное заклинание. Эти чары " +
                "усиливаются до уровня заклинания, равного половине вашего уровня округленного до " +
                "большего целого.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Unwavering mien",
                RussianName = "Непоколебимая наружность",
                Description = "Ваш мистический контроль и медитации позволяют вам противостоять внешним " +
                "воздействиям на ваше сознание. Каждый раз, когда на вас воздействует ментальный эффект " +
                "длящийся как минимум 2 раунда, вы можете уменьшить длительность на 1 раунд. Против " +
                "эффектов, которые погрузят вас в сон, вы считате свои спасброски на одну ступень " +
                "успешнее, но вам все еще требуется естественный сон.Это защищает только от эффектов " +
                "сна, а не от других форм потери сознания.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            #endregion

            #region Level5

            new DBFeat
            {
                Name = "Ageless patience",
                RussianName = "Вечное терпение",
                Description = "Вы работаете в темпе, приобретенном из-за долголетия, который повышает " +
                "вашу тщательность. Вы можете добровольно потратить в два раза больше времени на проверку " +
                "Восприятия или проверку навыка, чтобы получить бонус обстоятельства +2 к этой проверке. " +
                "Также, для этих проверок, вы не считаете натуральную 1 на кости как понижение степени " +
                "успешности; вы получаете критический провал только, если ваш результат на 10 меньше КС. " +
                "Например, вы можете получить эти преимущества если потратите два действия на Поиск, что " +
                "обычно занимает 1 действие. Вы можете получить эти преимущества во время исследования, " +
                "потратив в два раза больше времени, чем обычно требуется, или во время режима отдыха, " +
                "потратив в два раза больше времени отдыха. Мастер может решить, что ситуация не дает " +
                "вам преимущества, если промедление, наоборот, негативно отразится на результате, как " +
                "например при напряженных переговорах с нетерпеливым существом.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },
            new DBFeat
            {
                Name = "Elven weapon elegance",
                RussianName = "Изящество эльфийского оружия",
                Description = "Вы приспособились к обращению с оружием ваших эльфийских предков и " +
                "становитесь особенно смертельны в обращении с ним. Когда вы критически попадаете " +
                "используя эльфийское оружие, или одним из перечисленных в Знакомство с эльфийским " +
                "оружием, то применяете эффект критической специализации оружия.",
                Type = FeatType.Ancestory,
                Traits = new List<FeatTraits> { },
                Level = 5,
            },
            #endregion

            #endregion

            #endregion

            #region ClassFeats

            #region FighterFeats

            #region Level1

            new DBFeat
            {
                Name = "Double slice",
                RussianName = "Двойной разрез",
                Description = "Вы набрасываетесь на врага с обоими оружиями. Сделайте 2 " +
                    "Удара, по одному удару каждым из требуемых оружий ближнего боя, и для " +
                    "каждого используя ваш текущий штраф множественной атаки. Оба Удара должны" +
                    " быть по одной и той же цели. Если второй Удар сделан оружием, без " +
                    "признака быстрое, то он получает штраф -2. Если обе атаки попадают, " +
                    "объедините их урон и потом добавляйте любые другие применимые эффекты " +
                    "от обоих оружий. Вы добавляете любой точный урон только один раз, к атаке " +
                    "на свой выбор. Объедините урон от обоих Ударов и примените сопротивления " +
                    "и слабости только один раз. При расчете штрафа множественной атаки, это " +
                    "считается как 2 атаки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Exacting strike",
                RussianName = "Точный удар",
                Description = "Вы делаете контролируемую атаку, полностью учитывая ее " +
                "импульс. Сделайте Удар. Этот Удар получает следующий эффект провала. " +
                "Провал: Эта атака не считается при учете штрафа множественной атаки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Point-blank shot",
                RussianName = "Выстрел в упор",
                Description = "Вы прицеливаетесь, чтобы быстро подстрелить ближайшего " +
                "врага. Когда в этой стойке используете дистанционное оружие с признаком " +
                "залповое, то вы не получаете штраф к своим броскам атак от признака " +
                "залповое. Когда используете дистанционное оружие, которое без признака " +
                "залповое, вы получаете бонус обстоятельства +2 к броскам урона, против " +
                "целей в пределах первого шага дистанции оружия.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Power attack",
                RussianName = "Мощная атака",
                Description = "Вы проводите особенно мощную атаку, которая особенно сильно " +
                "бьет вашего врага, но оставляет вас немного неустойчивым. Сделайте Удар " +
                "ближнего боя. При подсчете вашего штрафа множественной атаки, он считается " +
                "как 2 атаки. Если этот Удар попадает, то вы наносите " +
                "дополнительную кость урона оружия. Если вы хотя бы 10-го уровня, " +
                "увеличьте количество дополнительных костей урона до 2, а если хотя " +
                "бы 18-го уровня, то до 3.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Reactive shield",
                RussianName = "Защитная реакция",
                Description = "Вы можете внезапно поднять щит, как если бы вы получили удар, " +
                "избегая попадания в последнюю секунду. Вы мгновенно используете действие Поднять щит " +
                "и получаете бонус к КБ от своего щита. Бонус обстоятельства от щита применяется к " +
                "вашему КБ когда вы определяете результат спровоцировавшей атаки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Snagging strike",
                RussianName = "Удар с захватом",
                Description = "Вы совмещаете атаку с быстрыми движениями для захвата, чтобы вывести " +
                "врага из равновесия, пока он остается в вашей досягаемости. Совершите Удар, имея одну " +
                "свободную руку. Если этот Удар попадает, то цель застигнута врасплох до начала вашего " +
                "следующего хода, или пока она больше не будет в пределах досягаемости вашей руки, в " +
                "зависимости от того, что произойдет раньше.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Snagging strike",
                RussianName = "Удар с захватом",
                Description = "Вы совмещаете атаку с быстрыми движениями для захвата, чтобы вывести " +
                "врага из равновесия, пока он остается в вашей досягаемости. Совершите Удар, имея одну " +
                "свободную руку. Если этот Удар попадает, то цель застигнута врасплох до начала вашего " +
                "следующего хода, или пока она больше не будет в пределах досягаемости вашей руки, в " +
                "зависимости от того, что произойдет раньше.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Sudden charge",
                RussianName = "Внезапное нападение",
                Description = "С быстрым рывком вы бросаетесь к врагу и наносите удар. Дважды сделайте " +
                "Перемещение. Если вы закончили перемещение в досягаемости ближнего боя хотя бы от " +
                "одного врага, то можете совершить по нему Удар ближнего боя. Вы можете использовать " +
                "Внезапное нападение, когда Роете, Карабкаетесь, Летите или Плывете вместо Перемещения, " +
                "если у вас есть соответствующий вид движения.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },

            #endregion

            #region Level2

            new DBFeat
            {
                Name = "Aggressive block",
                RussianName = "Агрессивное блокирование",
                Description = "Вы отталкиваетесь, блокируя атаку, сбивая противника в сторону или " +
                "выводя его из равновесия. Вы используете щит, либо автоматически Отталкивая " +
                "спровоцировавшее существо на 5 футов, либо делая его застигнутым врасплох до начала " +
                "вашего следующего хода. Спровоцировавшее существо выбирает, либо быть сдвинутым, " +
                "либо стать застигнутым врасплох. Если оно выбирает быть сдвинутым, то вы выбираете " +
                "направление. Если Толчок передвинет существо в твердый объект, оно войдет в квадрат " +
                "со сложной местностью или пространство другого существа, то оно должно стать " +
                "застигнутым врасплох, вместо того чтобы быть передвинутым.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Assisting shot",
                RussianName = "Вспомогательный выстрел",
                Description = "Быстрым выстрелом вы мешаете противнику в бою. Сделайте Удар " +
                "дистанционным оружием. Если Удар попадает, то следующее существо, кроме вас, которое " +
                "атакует ту же цель до начала вашего следующего хода получает бонус обстоятельства +1 к " +
                "своему броску, или бонус обстоятельства +2, если ваш Удар был критическим попаданием.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Brutish shove",
                RussianName = "Грубый толчок",
                Description = "Вкладывая свой вес в атаку, вы ударяете вашего противника с достаточной " +
                "силой, чтобы он оступился. Сделайте Удар двуручным оружием ближнего боя. Если вы " +
                "попадаете по цели своего или меньшего размера, это существо застигнуто врасплох до " +
                "конца вашего текущего хода, и вы можете автоматически Толкнуть его, с теми же " +
                "преимуществами, что и действием Толкнуть (включая эффект критического успеха, если " +
                "ваш Удар был критическим попаданием). Если вы двигаетесь следом за целью, то ваше " +
                "движение не провоцирует реакции. Этот Удар имеет следующий эффект провала. Провал: " +
                "Цель становится застигнута врасплох до конца вашего текущего хода.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Combat grab",
                RussianName = "Боевой захват",
                Description = "Вы бьете противника и хватаете его. Сделайте Удар ближнего боя, имея " +
                "одну свободную руку. Если атака попадает, то вы хватаете цель свободной рукой. " +
                "Существо остается схвачено до конца вашего следующего хода или пока не сможет " +
                "Вырваться, в зависимости от того, что произойдет раньше.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Dueling parry",
                RussianName = "Дуэльное парирование",
                Description = "Вы можете парировать атаки против вас, своим одноручным оружием. Вы " +
                "получаете бонус обстоятельства +2 к КБ до начала вашего следующего хода, пока " +
                "соответствуете требованиям.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Intimidating strike",
                RussianName = "Запугивающий удар",
                Description = "Ваш удар не только ранит существо, но так же вселяет в него " +
                "неуверенность. Сделайте Удар ближнего боя. Если вы попали и нанесли урон, цель " +
                "получаете состояние напуган 1, или напуган 2 при крит.попадании.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Lunge",
                RussianName = "Выпад",
                Description = "Вытягивая своей тело до максимума, вы атакуете врага, который обычно " +
                "был бы вне досягаемости. Сделайте Удар оружием ближнего боя, увеличивая досягаемость " +
                "этой атаки на 5 футов. Если оружие имеет признак разоружение, толчок или опрокидывание, " +
                "вы можете использовать соответствующее действие вместо Удара.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            #endregion

            #region Level4

            new DBFeat
            {
                Name = "Double shot",
                RussianName = "Двойной выстрел",
                Description = "Вы ослепительно быстро стреляете два раза подряд. Сделайте 2 Выстрела, " +
                "каждый по отдельной цели и со штрафом -2. Обе атаки считаются к вашему штрафу " +
                "множественной атаки, но он не увеличивается пока вы не закончите эти атаки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Dual-handed assault",
                RussianName = "Двуручное нападение",
                Description = "Вы фиксируете свободную руку на рукояти, чтобы сжать свое оружие " +
                "достаточно долго, чтобы вложить больше силы, и нанести более мощный удар противнику. " +
                "Совершите Удар требуемым оружием. Вы быстро меняете хватку во время Удара, чтобы " +
                "сделать двуручную атаку. Если оружие обычно не имеет признака двуручное, увеличьте " +
                "его размер кости урона для этой атаки на один шаг. Если оружие имеет признак двуручное, " +
                "то вы получаете преимущество этого признака и бонус обстоятельства к урону, равный " +
                "количеству костей урона оружия. Когда Удар завершен, вы продолжаете держать оружие " +
                "только одной рукой. Это действие не заканчивает стойки или эффект способности воина, " +
                "который требует от вас наличия свободной руки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Knockdown",
                RussianName = "Нокдаун",
                Description = "Вы делаете атаку, чтобы вывести противника из равновесия, а затем " +
                "мгновенно продолжаете нападение, опрокидывая его. Сделайте Удар ближнего боя. Если он " +
                "попадает и наносит урон, вы можете совершить проверку Атлетики, чтобы Опрокинуть это " +
                "существо. Если вы владеете двуручным оружием ближнего боя, то можете игнорировать " +
                "требование Опрокидывания о наличии свободной руки. Обе атаки считаются к вашему штрафу " +
                "множественной атаки, но он не увеличивается пока вы не закончите эти атаки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Powerful shove",
                RussianName = "Мощный толчок",
                Description = "Своей атакой, вы можете толкнуть противника бо́льшего размера. Вы " +
                "можете использовать Агрессивное блокирование или Грубый толчок против существа вплоть " +
                "до 2 размеров больше вас. Когда существо, которое вы Толкаете должно остановиться из-за " +
                "столкновения с объектом, оно получает урон равный вашему модификатору Силы (минимально " +
                "1).Это происходит не зависимо от того, как вы Толкнули существо.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Quick reversal",
                RussianName = "Быстрый разворот",
                Description = "Быстрым разворотом, вы оборачиваете взятие вас в тиски против самих " +
                "врагов. Нанесите Удар ближнего боя по одному из врагов, взявших вас в тиски, а потом " +
                "второй Удар, тем же оружием или безоружной атакой, по другому врагу взявшему вас в " +
                "тиски. Второй Удар имеет тот же штраф множественной атаки, что и начальная атака, и не " +
                "считается к вашему штрафу множественной атаки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Shielded stride",
                RussianName = "Защитное перемещение",
                Description = "Когда вы за щитом, удары врагов не могут попасть по вам. Когда у вас " +
                "поднят щит, вы можете Перемещаться вплоть до половины своей Скорости не провоцируя " +
                "реакции, которые обычно срабатывают при движении (такие как Возможность для атаки). " +
                "Вы можете использовать Защитное перемещение, когда Летите или Плывете, если у вас " +
                "есть соответствующий вид передвижения.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Swipe",
                RussianName = "Взмах",
                Description = "Вы делаете широкий удар по дуге. Сделайте 1 Удар ближнего боя и " +
                "сравните результат броска атаки с КБ вплоть до 2 врагов, каждый из которых должен " +
                "быть в пределах досягаемости вашей атаки ближнего боя, и находиться рядом друг с " +
                "другом. Сделайте бросок урона только 1 раз, и используйте это значение для каждого " +
                "существа по которому вы попали. Взмах считается как 2 атаки для вашего штрафа " +
                "множественной атаки. Если вы используете оружие с признаком размах, то его " +
                "модификатор применяется для всех атак Взмаха.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Twin parry",
                RussianName = "Парное парирование",
                Description = "Вы используете два оружия, чтобы парировать атаки. До начала своего " +
                "следующего хода вы получаете бонус обстоятельства +1 к КБ, или бонус обстоятельства +2, " +
                "если одно из оружий имеет признак парирование. Вы теряете этот бонус обстоятельства, " +
                "если больше не удовлетворяете требования способности.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            #endregion

            #endregion

            #region ChampionFeats

            #region Level1

            new DBFeat
            {
                Name = "Deity's domain",
                RussianName = "Домен божества",
                Description = "Вы олицетворяете аспект своего божества. Выберите один из доменов " +
                "вашего божества. Вы получаете начальное заклинание домена, как заклинание преданности.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Ranged reprisal",
                RussianName = "Расправа на расстоянии",
                Description = "Вы можете использовать Карающий удар с дистанционным оружием. " +
                "Дополнительно, если враг, спровоцировавший вашу реакцию, находится в 5 футах от " +
                "вашей досягаемости, но еще не в ее пределах, то до атаки Карающим ударом, " +
                "как часть реакции, вы можете сделать Шаг, чтобы враг оказался в досягаемости.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Unimpeded step",
                RussianName = "Беспрепятственный шаг",
                Description = "Благодаря порыву божественного освобождения от Освобождающий шаг, " +
                "передвижение вашего союзника не подвергается воздействию сложной местности, " +
                "особо сложной местности, узкой поверхности, и неровной поверхности.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Weight of guilt",
                RussianName = "Тяжесть вины",
                Description = "Вина затмевает разумы тех, кто игнорирует Проблеск искупления. " +
                "Вместо того, чтобы дать спровоцировавшему существу состояние ослаблен 2, вы " +
                "можете дать ему состояние одурманен 2 с той же продолжительностью.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 1,
            },
            #endregion

            #region Level2

            new DBFeat
            {
                Name = "Divine grace",
                RussianName = "Божественная милость",
                Description = "Вы взываете к милости вашего божества, получая бонус " +
                "обстоятельства +2 к этому спасброску.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Dragonslayer oath",
                RussianName = "Клятва убийцы драконов",
                Description = "Вы поклялись убивать злых драконов. Добавьте следующие " +
                "принципы в ваш кодекс, после всех остальных: Вы должны убивать " +
                "встреченных злых драконов, пока у вас есть приемлемые шансы на успех. " +
                "Ваш Карающий удар получает бонус обстоятельства +4 к урону против " +
                "злых драконов, или +6 если вы мастер с используемым оружием. Ваше " +
                "сопротивление Проблеск искупления против урона от злых драконов " +
                "становится 7 + ваш уровень.Если вы используете Освобождающий шаг, " +
                "спровоцированный злым драконом, ваш союзник получает бонус " +
                "обстоятельства +4 на полученные проверки, и после этого, он может " +
                "дважды использовать Шаг. Вы не считаете злых драконов законными " +
                "правителями, даже у народов, где они правят.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { FeatTraits.Oath },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Fiendsbane oath",
                RussianName = "Клятва изгоняющего бесов",
                Description = "Вы поклялись изгонять порочных бесов обратно, на " +
                "планы тьмы, которые они считают своим домом. Добавьте следующие " +
                "принципы в ваш кодекс, после всех остальных: Вы должны изгонять " +
                "или убивать встреченных бесов, пока у вас есть приемлемые шансы " +
                "на успех; при маловероятном случае, если вы найдете хорошего " +
                "беса, вы не должны убивать или изгонять его. Ваш Карающий удар " +
                "получает бонус обстоятельства +4 к урону против бесов, или +6 " +
                "если вы мастер с используемым оружием. Ваше сопротивление " +
                "Проблеск искупления против урона от бесов становится 7 + ваш " +
                "уровень. Если вы используете Освобождающий шаг, спровоцированный " +
                "бесом, ваш союзник получает бонус обстоятельства +4 на полученные " +
                "проверки, и после этого, он может дважды использовать Шаг. Вы не " +
                "считаете бесов законными правителями, даже у народов, где они правят.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { FeatTraits.Oath },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Vengeful oath",
                RussianName = "Клятва мести",
                Description = "Вы поклялись поймать злодеев и предать их суду. " +
                "Добавьте следующие принципы в ваш кодекс, после всех остальных: " +
                "Вы должны выслеживать и искоренять злых существ, которые совершили " +
                "чудовищные поступки, пока у вас есть приемлемые шансы на успех, и " +
                "вы не участвуете в миссии, которая помешала бы вам сделать это. Вы " +
                "можете использовать Наложение рук, чтобы нанести урон существу, как " +
                "если бы он был нежитью, которое при вас совершало вред невинным или " +
                "доброму союзнику; в этом случае, наложение рук причиняет урон добром, " +
                "а не позитивной энергией и получает признак добро. Этот урон добром " +
                "может действовать на незлых существ. Это не мешает вам лечить этих " +
                "существ с помощью наложения рук, вы сами выбираете эффект исцеления " +
                "или нанесения ран.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { FeatTraits.Oath },
                Level = 2,
            },
            #endregion

            #region Level4

            new DBFeat
            {
                Name = "Aura of courage",
                RussianName = "Аура смелости",
                Description = "Вы твердо стоите перед лицом опасности и вдохновляете " +
                "своих союзников делать так же. Когда вы получаете состояние напуган, " +
                "уменьшите значение состояния на 1 (до минимум 0). В конце вашего хода, " +
                "когда вы уменьшаете свое состояние напуган на 1, то вы еще снижаете " +
                "его на 1 для всех союзников в пределах 15 футов от вас.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Divine health",
                RussianName = "Божественное здоровье",
                Description = "Ваша вера делает вас устойчивыми к болезням, защищая вас, " +
                "когда вы предлагаете помощь больным. Вы получаете бонус состояния +1 к " +
                "спасброскам против болезней. Дополнительно, если при броске спасброска " +
                "против болезни вы получаете успех, то вместо этого получаете критический " +
                "успех.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Mercy",
                RussianName = "Милосердие",
                Description = "Ваше прикосновение снимает страх и восстанавливает движение. " +
                "Если ваше следующее действие - использование Наложение рук, помимо других " +
                "преимуществ, вы можете попытаться противодействовать эффекту страха или " +
                "эффекту наложившему на цель состояние парализован.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits>() { },
                Level = 4,
            },
            #endregion


            #endregion

            #region AlchemistFeats

            #region Level1

            new DBFeat
            {
                Name = "Alchemical familiar",
                RussianName = "Алхимический фамильяр",
                Description = "Вы использовали алхимию для создания жизни, сделав простое существо " +
                "из алхимических материалов, реагентов и чуть-чуть своей собственной крови. Этот " +
                "алхимический фамильяр выглядит как маленькое существо из плоти и крови, хотя он " +
                "может иметь некоторые необычные или отличительные черты в зависимости от вашего " +
                "творческого процесса. Как и другие фамильяры, ваш алхимический фамильяр помогает " +
                "вам в лаборатории и приключениях. Фамильяр использует ваш модификатор Интеллекта " +
                "для определения его модификаторов Восприятия, Акробатики и Скрытности.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Alchemical savant",
                RussianName = "Специалист алхимии",
                Description = "Вы можете быстро идентифицировать алхимические предметы. Когда вы " +
                "используете навык Ремесла для Идентификация алхимии на алхимическом предмете, " +
                "который держите, то можете сделать это не за 10 минут как обычно, а за одно " +
                "действие, которое имеет признаки воздействие и концентрация. Если у вас есть " +
                "формула предмета, который вы пытаетесь идентифицировать, то получаете бонус " +
                "обстоятельства +2 к проверке, и если при броске получаете крит.провал, то он " +
                "становится просто провалом.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Far lobber",
                RussianName = "Метатель вдаль",
                Description = "Вы научились дальше метать бомбы. Когда вы бросаете алхимическую " +
                "бомбу, то ее шаг дистанции 30 футов, вместо обычных 20 футов.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Quick bomber",
                RussianName = "Быстрый бомбометатель",
                Description = "Вы храните свои бомбы в легкодоступных мешочках, из которых не " +
                "задумываясь достаете их. Вы используете Взаимодействовать, чтобы достать бомбу " +
                "и потом Бросаете ее.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            #endregion

            #region Level2

            new DBFeat
            {
                Name = "Poison resistance",
                RussianName = "Сопротивление яду",
                Description = "Многократное воздействие токсичных реагентов укрепило ваш " +
                "организм против всевозможных ядов. Вы получаете сопротивление яду равное " +
                "половине вашего уровня, а так же бонус состояния +1 к спасброскам против ядов.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Revivifying mutagen",
                RussianName = "Восстанавливающий мутаген",
                Description = "Находясь под действием мутагена, вы можете метаболизировать " +
                "его силу, чтобы исцелять себя. Для этого используется одиночное действие, " +
                "которое имеет признаки воздействие и концентрация. Как только действие " +
                "завершено, вы восстанавливаете 1d6 ОЗ за каждые 2 уровня предмета " +
                "мутагена (минимум 1d6), но продолжительность мутагена мгновенно " +
                "заканчивается, даже если вы под эффектом от Постоянного мутагена.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Smoke bomb",
                RussianName = "Дымовая бомба",
                Description = "В дополнение к ее обычным эффектам, вы заставляете бомбу " +
                "создавать облако густого дыма. Когда брошена, бомба создает облако дыма в форме " +
                "10-футового взрыва. Вы выбираете какой из углов пространства цели (или " +
                "пространства, в котором падает бомба) является центром. Существа в этой области " +
                "имеют состояние скрыт и все другие существа скрыты для них. Дым длится 1 минуту " +
                "или пока не будет развеян сильным ветром.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { FeatTraits.Additive },
                Level = 2,
            },

            #endregion

            #region Level4

            new DBFeat
            {
                Name = "Calculated splash",
                RussianName = "Рассчитанные брызги",
                Description = "Вы рассчитали все углы, чтобы максимизировать брызги от бомбы. " +
                "Когда вы бросаете алхимическую бомбу с признаком брызги, то вместо обычного " +
                "значения, можете заставить бомбу нанести урон брызгами, равный вашему " +
                "модификатору Интеллекта (минимум 0).",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Efficient alchemy",
                RussianName = "Эффективная алхимия",
                Description = "Благодаря времени, которое вы потратили на изучение и эксперименты, " +
                "вы знаете, как масштабировать свои формулы на более крупные партии, которые не " +
                "требуют дополнительного внимания. Когда во время отдыха вы Создаете алхимические " +
                "предметы, то можете производить в два раза больше алхимических предметов за " +
                "одну партию, не тратя дополнительного времени на подготовку. Например, если во " +
                "время отдыха вы создаете Эликсир жизни, то можете создать вплоть до 8 эликсиров " +
                "в одной партии, а не 4 как обычно. Это не снижает количество требуемых " +
                "алхимических реагентов или других ингредиентов для создания каждого предмета, " +
                "и не увеличивает ваш прогресс в днях после основного времени отдыха. Еще это " +
                "не изменяет количество предметов, которое вы можете сделать одной партией при " +
                "использовании продвинутой алхимии.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Enduring alchemy",
                RussianName = "Стойкая алхимия",
                Description = "Вы узнали, как сделать так, чтобы ваши смеси оставались действенными " +
                "чуть дольше, когда быстро смешиваете разовые отвары. При использовании Быстрая " +
                "алхимия для создания алхимического инструмента или эликсира, этот эликсир или " +
                "инструмент остается действующим до конца вашего следующего хода, а не теряет эффект " +
                "в начале вашего следующего хода.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            #endregion

            #endregion

            #region WizardFeats

            #region Level1

            new DBFeat
            {
                Name = "Counterspell",
                RussianName = "Контрзаклинание",
                Description = "Когда враг Сотворяет заклинание, которое вы знаете, и вы можете видеть " +
                "его проявления, то можете использовать свою магию, чтобы противостоять ему. Вы " +
                "расходуете подготовленное заклинание, чтобы противостоять существу, творящему это же " +
                "заклинание. Вы теряете свой слот заклинания, как если бы сотворили спровоцировавшее " +
                "заклинание. Потом вы пытаетесь противодействовать спровоцировавшему заклинанию.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Eschew materials",
                RussianName = "Отказ от материалов",
                Description = "Вы можете использовать хитроумные обходные пути, чтобы воспроизвести " +
                "арканную сущность определенных материалов. Когда делает Сотворение заклинания, " +
                "которое требует материальных компонентов, вы можете предоставить их без сумки с " +
                "материальными компонентами, рисуя в воздухе причудливые, заменяющие их, символы. " +
                "В отличие от предоставления жестовых компонентов, вы все еще должны иметь полностью " +
                "свободную руку. Это не убирает нужды в любых материалах, указанных в записи " +
                "заклинания Стоимость.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Familiar",
                RussianName = "Фамильяр",
                Description = "Вы заключаете договор с существом, которое служит вам и помогает " +
                "вашему колдовству. Вы получаете фамильяра.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Hand of the apprentice",
                RussianName = "Рука ученика",
                Description = "Вы можете магически швырнуть свое оружие в противника. Вы получаете " +
                "заклинание универсалиста Рука ученика. Заклинания универсалиста это вид заклинаний " +
                "фокусировки, как заклинания школы магии. Вы начинаете с запасом Очков Фокусировки, " +
                "равным 1. Смотрите Арканные школы для подробной информации о заклинания фокусировки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Reach spell",
                RussianName = "Досягаемое заклинание",
                Description = "Вы можете увеличить дистанцию своих заклинаний. Если ваше следующее " +
                "действие - Сотворение заклинания, у которого есть дистанция, увеличьте дистанцию " +
                "заклинания на 30 футов. Как обычно при увеличении дистанций заклинания, если оно " +
                "имеет дистанцию касания, то вы увеличиваете его дистанцию до 30 футов.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            new DBFeat
            {
                Name = "Widen spell",
                RussianName = "Расширенное заклинание",
                Description = "Вы управляете энергией заклинания, заставляя его воздействовать на " +
                "область шире обычного. Если ваше следующее действие - Сотворение заклинания, у " +
                "которого есть область взрыва, конуса или линии, и оно не имеет продолжительности, " +
                "то увеличьте область этого заклинания. Добавьте 5 футов к радиусу взрыва, который " +
                "обычно имеет радиус хотя бы 10 футов (не имеет эффекта на взрыв с меньшим радиусом). " +
                "Добавьте 5 футов к длине конуса или линии, которые обычно имеют длину 15 футов или " +
                "менее, и добавьте 10 футов к длине бо́льшего конуса и линии.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 1,
            },
            #endregion

            #region Level2

            new DBFeat
            {
                Name = "Cantrip expansion",
                RussianName = "Расширение чар",
                Description = "Специализированное обучение позволяет вам подготавливать более " +
                "широкий диапазон простых заклинаний. Вы можете подготавливать 2 дополнительных " +
                "чар каждый день.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Conceal spell",
                RussianName = "Скрыть заклинание",
                Description = "Скрывая свои жесты и магические формулы другими речами и движениями, " +
                "вы пытаетесь скрыть тот факт, что вы делаете Сотворение заклинания. Если " +
                "следующее действие - Сотворение заклинания, сделайте проверку Скрытности против " +
                "КС Восприятия одного или нескольких наблюдателей; если заклинание имеет словесные " +
                "компоненты, вы еще должны сделать проверку Обмана против КС Восприятия наблюдателей. " +
                "Если вы успешно прошли проверку (или проверки) против КС наблюдателя, этот " +
                "наблюдатель не замечает, что вы сотворяете заклинание, хотя материальные, жестовые " +
                "и словесные компоненты обычно заметны и заклинания обычно имеют сенсорные проявления, " +
                "которые сделали бы колдовство очевидным для тех, кто рядом. Это умение скрывает " +
                "только заклинательские действия и проявления, а не его эффекты, так что наблюдатель " +
                "все равно может увидеть исходящий от вас луч, или увидеть, как вы растворяетесь в воздухе.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            new DBFeat
            {
                Name = "Enhanced familiar",
                RussianName = "Усиленный фамильяр",
                Description = "Вы наполняете своего фамильяра дополнительной магической энергией. Вы можете " +
                "выбрать 4 способности фамильяра или хозяина каждый день, вместо 2. Особенность: Если ваша " +
                "арканная диссертация - Улучшенная связь с фамильяром, то количество изначальных способностей " +
                "вашего фамильяра, до добавления любых дополнительных способностей от диссертации, равняется 4.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 2,
            },
            #endregion

            #region Level4

            new DBFeat
            {
                Name = "Bespell weapon",
                RussianName = "Околдованное оружие",
                Description = "Вы наполняете одно оружие, которым владеете, остаточной энергией последнего " +
                "сотворенного заклинания. До конца вашего хода, оружие наносит дополнительные 1d6 урона, тип " +
                "которого зависит от школы только что сотворенного заклинания. Преграждение: урон силой, " +
                "Воплощение или Трансмутация: тот же тип урона, что и у оружия, Прорицание, Очарование или " +
                "Иллюзия: ментальный урон, Эвокация: тип наносимый заклинанием, или силой, если заклинание " +
                "не наносит урон, Некромантия: негативный урон.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Linked focus",
                RussianName = "Связанный фокус",
                Description = "Вы связали ваш предмет силы с колодцем энергии, который питает ваши заклинания " +
                "школы. Когда вы используете Истощить предмет силы, чтобы сотворить заклинание своей арканной " +
                "школы, то еще можете восстановить 1 Очко Фокусировки.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            },
            new DBFeat
            {
                Name = "Silent spell",
                RussianName = "Тихое заклинание",
                Description = "Вы научились как сотворять многие из своих заклинаний не произнося слов силы, " +
                "которые обычно требуются. Если ваше следующее действие - Сотворение заклинания, которое имеет " +
                "словесную компоненту и как минимум одну другую компоненту, то вы можете убрать словесную " +
                "компоненту. Это делате заклинание тихим и позволяет вам колдовать его в тех местах, где нет " +
                "звуков. Однако, заклинание все еще имеет визуальные проявления, так что это не делает его менее " +
                "очевидным для кого-то, кто видит как вы его творите. Когда вы используете Тихое заклинание, то " +
                "можете выбрать преимущества Скрыть заклинание, и вам не требуется проходить проверку Обмана, " +
                "потому что заклинание не имеет словесных компонент.",
                Type = FeatType.Class,
                Traits = new List<FeatTraits> { },
                Level = 4,
            }
            #endregion

            #endregion

            #endregion
            );
            #endregion

            #region Actions

            modelBuilder.Entity<DBAction>().HasData(

            #region GoblinActions

            new DBAction
            {
                Name = "Goblin scuttle",
                RussianName = "Гоблинское увиливание",
                Description = "Вы получаете преимущество от перемещения вашего союзника, чтобы выбрать " +
                "себе место поудобней. Вы делаете Шаг.",
                Requirement = "",
                Trigger = "Союзник закончил перемещение рядом с вами.",
                Type = ActionType.Reaction,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Goblin song",
                RussianName = "Гоблинская песенка",
                Description = "Вы поете надоедливые гоблинские песенки, отвлекая своих врагов глупыми " +
                "и повторяющимися текстами. Сделайте проверку Выступления против КС Воли одного врага " +
                "в пределах 30 футов. Это действие имеет обычные признаки и ограничения проверки " +
                "Выступления. Вы можете воздействовать на 2 цели в пределах дистанции, если вы эксперт " +
                "Выступления, на 4 если вы мастер, и на 8 если легенда. Критический успех: Цель " +
                "получает штраф состояния - 1 к проверкам Восприятия и спасброскам Воли на 1 минуту. " +
                "Успех: Цель получает штраф состояния - 1 к проверкам Восприятия и спасброскам Воли на " +
                "1 раунд. Критический провал: Цель временно иммунна к попыткам использования Гоблинской " +
                "песенки на 1 час.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { },
            },
            #endregion

            #region FighterActions

            new DBAction
            {
                Name = "Double slice",
                RussianName = "Двойной разрез",
                Description = "Вы набрасываетесь на врага с обоими оружиями. Сделайте 2 " +
                    "Удара, по одному удару каждым из требуемых оружий ближнего боя, и для " +
                    "каждого используя ваш текущий штраф множественной атаки. Оба Удара должны" +
                    " быть по одной и той же цели. Если второй Удар сделан оружием, без " +
                    "признака быстрое, то он получает штраф -2. Если обе атаки попадают, " +
                    "объедините их урон и потом добавляйте любые другие применимые эффекты " +
                    "от обоих оружий. Вы добавляете любой точный урон только один раз, к атаке " +
                    "на свой выбор. Объедините урон от обоих Ударов и примените сопротивления " +
                    "и слабости только один раз. При расчете штрафа множественной атаки, это " +
                    "считается как 2 атаки.",
                Requirement = "Вы владеете двумя оружиями ближнего боя, каждое в отдельной руке.",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Exacting strike",
                RussianName = "Точный удар",
                Description = "Вы делаете контролируемую атаку, полностью учитывая ее " +
                "импульс. Сделайте Удар. Этот Удар получает следующий эффект провала. " +
                "Провал: Эта атака не считается при учете штрафа множественной атаки.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { ActionTraits.Press },
            },
            new DBAction
            {
                Name = "Point-blank shot",
                RussianName = "Выстрел в упор",
                Description = "Вы прицеливаетесь, чтобы быстро подстрелить ближайшего " +
                "врага. Когда в этой стойке используете дистанционное оружие с признаком " +
                "залповое, то вы не получаете штраф к своим броскам атак от признака " +
                "залповое. Когда используете дистанционное оружие, которое без признака " +
                "залповое, вы получаете бонус обстоятельства +2 к броскам урона, против " +
                "целей в пределах первого шага дистанции оружия.",
                Requirement = "Вы владеете дистанционным оружием.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Stance,
                    ActionTraits.Open
                },
            },
            new DBAction
            {
                Name = "Power attack",
                RussianName = "Мощная атака",
                Description = "Вы проводите особенно мощную атаку, которая особенно сильно " +
                "бьет вашего врага, но оставляет вас немного неустойчивым. Сделайте Удар " +
                "ближнего боя. При подсчете вашего штрафа множественной атаки, он считается " +
                "как 2 атаки. Если этот Удар попадает, то вы наносите " +
                "дополнительную кость урона оружия. Если вы хотя бы 10-го уровня, " +
                "увеличьте количество дополнительных костей урона до 2, а если хотя " +
                "бы 18-го уровня, то до 3.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits> { ActionTraits.Flourism },
            },
            new DBAction
            {
                Name = "Reactive shield",
                RussianName = "Защитная реакция",
                Description = "Вы можете внезапно поднять щит, как если бы вы получили удар, " +
                "избегая попадания в последнюю секунду. Вы мгновенно используете действие Поднять щит " +
                "и получаете бонус к КБ от своего щита. Бонус обстоятельства от щита применяется к " +
                "вашему КБ когда вы определяете результат спровоцировавшей атаки.",
                Requirement = "Вы владеете щитом.",
                Trigger = "Враг попадает по вам Ударом ближнего боя.",
                Type = ActionType.Reaction,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Snagging strike",
                RussianName = "Удар с захватом",
                Description = "Вы совмещаете атаку с быстрыми движениями для захвата, чтобы вывести " +
                "врага из равновесия, пока он остается в вашей досягаемости. Совершите Удар, имея одну " +
                "свободную руку. Если этот Удар попадает, то цель застигнута врасплох до начала вашего " +
                "следующего хода, или пока она больше не будет в пределах досягаемости вашей руки, в " +
                "зависимости от того, что произойдет раньше.",
                Requirement = "У вас есть одна свободная рука, и цель в досягаемости этой руки.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Sudden charge",
                RussianName = "Внезапное нападение",
                Description = "С быстрым рывком вы бросаетесь к врагу и наносите удар. Дважды сделайте " +
                "Перемещение. Если вы закончили перемещение в досягаемости ближнего боя хотя бы от " +
                "одного врага, то можете совершить по нему Удар ближнего боя. Вы можете использовать " +
                "Внезапное нападение, когда Роете, Карабкаетесь, Летите или Плывете вместо Перемещения, " +
                "если у вас есть соответствующий вид движения.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Flourism,
                    ActionTraits.Open
                },
            },
            new DBAction
            {
                Name = "Aggressive block",
                RussianName = "Агрессивное блокирование",
                Description = "Вы отталкиваетесь, блокируя атаку, сбивая противника в сторону или " +
                "выводя его из равновесия. Вы используете щит, либо автоматически Отталкивая " +
                "спровоцировавшее существо на 5 футов, либо делая его застигнутым врасплох до начала " +
                "вашего следующего хода. Спровоцировавшее существо выбирает, либо быть сдвинутым, " +
                "либо стать застигнутым врасплох. Если оно выбирает быть сдвинутым, то вы выбираете " +
                "направление. Если Толчок передвинет существо в твердый объект, оно войдет в квадрат " +
                "со сложной местностью или пространство другого существа, то оно должно стать " +
                "застигнутым врасплох, вместо того чтобы быть передвинутым.",
                Requirement = "",
                Trigger = "Вы используете реакцию Блок щитом, и спровоцировавший противник, вашего " +
                "или меньшего размера, находится рядом с вами.",
                Type = ActionType.Free,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Assisting shot",
                RussianName = "Вспомогательный выстрел",
                Description = "Быстрым выстрелом вы мешаете противнику в бою. Сделайте Удар " +
                "дистанционным оружием. Если Удар попадает, то следующее существо, кроме вас, которое " +
                "атакует ту же цель до начала вашего следующего хода получает бонус обстоятельства +1 к " +
                "своему броску, или бонус обстоятельства +2, если ваш Удар был критическим попаданием.",
                Requirement = "Вы владеете дистанционным оружием.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { ActionTraits.Press },
            },
            new DBAction
            {
                Name = "Brutish shove",
                RussianName = "Грубый толчок",
                Description = "Вкладывая свой вес в атаку, вы ударяете вашего противника с достаточной " +
                "силой, чтобы он оступился. Сделайте Удар двуручным оружием ближнего боя. Если вы " +
                "попадаете по цели своего или меньшего размера, это существо застигнуто врасплох до " +
                "конца вашего текущего хода, и вы можете автоматически Толкнуть его, с теми же " +
                "преимуществами, что и действием Толкнуть (включая эффект критического успеха, если " +
                "ваш Удар был критическим попаданием). Если вы двигаетесь следом за целью, то ваше " +
                "движение не провоцирует реакции. Этот Удар имеет следующий эффект провала. Провал: " +
                "Цель становится застигнута врасплох до конца вашего текущего хода.",
                Requirement = "Вы владеете двуручным оружием ближнего боя.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { ActionTraits.Press },
            },
            new DBAction
            {
                Name = "Combat grab",
                RussianName = "Боевой захват",
                Description = "Вы бьете противника и хватаете его. Сделайте Удар ближнего боя, имея " +
                "одну свободную руку. Если атака попадает, то вы хватаете цель свободной рукой. " +
                "Существо остается схвачено до конца вашего следующего хода или пока не сможет " +
                "Вырваться, в зависимости от того, что произойдет раньше.",
                Requirement = "У вас есть одна свободная рука, и цель в досягаемости этой руки.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { ActionTraits.Press },
            },
            new DBAction
            {
                Name = "Dueling parry",
                RussianName = "Дуэльное парирование",
                Description = "Вы можете парировать атаки против вас, своим одноручным оружием. Вы " +
                "получаете бонус обстоятельства +2 к КБ до начала вашего следующего хода, пока " +
                "соответствуете требованиям.",
                Requirement = "Вы владеете только одним одноручным оружием ближнего боя и ваша другая " +
                "рука(и) свободны.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Intimidating strike",
                RussianName = "Запугивающий удар",
                Description = "Ваш удар не только ранит существо, но так же вселяет в него " +
                "неуверенность. Сделайте Удар ближнего боя. Если вы попали и нанесли урон, цель " +
                "получаете состояние напуган 1, или напуган 2 при крит.попадании.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Fear,
                    ActionTraits.Emotion,
                    ActionTraits.Mental
                },
            },
            new DBAction
            {
                Name = "Lunge",
                RussianName = "Выпад",
                Description = "Вытягивая своей тело до максимума, вы атакуете врага, который обычно " +
                "был бы вне досягаемости. Сделайте Удар оружием ближнего боя, увеличивая досягаемость " +
                "этой атаки на 5 футов. Если оружие имеет признак разоружение, толчок или опрокидывание, " +
                "вы можете использовать соответствующее действие вместо Удара.",
                Requirement = "Вы владеете оружием ближнего боя/",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { },
            },
            new DBAction
            {
                Name = "Double shot",
                RussianName = "Двойной выстрел",
                Description = "Вы ослепительно быстро стреляете два раза подряд. Сделайте 2 Выстрела, " +
                "каждый по отдельной цели и со штрафом -2. Обе атаки считаются к вашему штрафу " +
                "множественной атаки, но он не увеличивается пока вы не закончите эти атаки.",
                Requirement = "Вы владеете дистанционным оружием с перезарядкой 0.",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Flourism,
                },
            },
            new DBAction
            {
                Name = "Dual-handed assault",
                RussianName = "Двуручное нападение",
                Description = "Вы фиксируете свободную руку на рукояти, чтобы сжать свое оружие " +
                "достаточно долго, чтобы вложить больше силы, и нанести более мощный удар противнику. " +
                "Совершите Удар требуемым оружием. Вы быстро меняете хватку во время Удара, чтобы " +
                "сделать двуручную атаку. Если оружие обычно не имеет признака двуручное, увеличьте " +
                "его размер кости урона для этой атаки на один шаг. Если оружие имеет признак двуручное, " +
                "то вы получаете преимущество этого признака и бонус обстоятельства к урону, равный " +
                "количеству костей урона оружия. Когда Удар завершен, вы продолжаете держать оружие " +
                "только одной рукой. Это действие не заканчивает стойки или эффект способности воина, " +
                "который требует от вас наличия свободной руки.",
                Requirement = "Вы владеете одноручным оружием ближнего боя и имеете свободную руку.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Flourism,
                },
            },
            new DBAction
            {
                Name = "Knockdown",
                RussianName = "Нокдаун",
                Description = "Вы делаете атаку, чтобы вывести противника из равновесия, а затем " +
                "мгновенно продолжаете нападение, опрокидывая его. Сделайте Удар ближнего боя. Если он " +
                "попадает и наносит урон, вы можете совершить проверку Атлетики, чтобы Опрокинуть это " +
                "существо. Если вы владеете двуручным оружием ближнего боя, то можете игнорировать " +
                "требование Опрокидывания о наличии свободной руки. Обе атаки считаются к вашему штрафу " +
                "множественной атаки, но он не увеличивается пока вы не закончите эти атаки.",
                Requirement = "Обучен Атлетике.",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Flourism,
                },
            },
            new DBAction
            {
                Name = "Quick reversal",
                RussianName = "Быстрый разворот",
                Description = "Быстрым разворотом, вы оборачиваете взятие вас в тиски против самих " +
                "врагов. Нанесите Удар ближнего боя по одному из врагов, взявших вас в тиски, а потом " +
                "второй Удар, тем же оружием или безоружной атакой, по другому врагу взявшему вас в " +
                "тиски. Второй Удар имеет тот же штраф множественной атаки, что и начальная атака, и не " +
                "считается к вашему штрафу множественной атаки.",
                Requirement = "Вы взяты в тиски минимум 2 врагами.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Flourism,
                    ActionTraits.Press
                },
            },
            new DBAction
            {
                Name = "Swipe",
                RussianName = "Взмах",
                Description = "Вы делаете широкий удар по дуге. Сделайте 1 Удар ближнего боя и " +
                "сравните результат броска атаки с КБ вплоть до 2 врагов, каждый из которых должен " +
                "быть в пределах досягаемости вашей атаки ближнего боя, и находиться рядом друг с " +
                "другом. Сделайте бросок урона только 1 раз, и используйте это значение для каждого " +
                "существа по которому вы попали. Взмах считается как 2 атаки для вашего штрафа " +
                "множественной атаки. Если вы используете оружие с признаком размах, то его " +
                "модификатор применяется для всех атак Взмаха.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Two,
                Traits = new List<ActionTraits> { ActionTraits.Flourism },
            },
            new DBAction
            {
                Name = "Twin parry",
                RussianName = "Парное парирование",
                Description = "Вы используете два оружия, чтобы парировать атаки. До начала своего " +
                "следующего хода вы получаете бонус обстоятельства +1 к КБ, или бонус обстоятельства +2, " +
                "если одно из оружий имеет признак парирование. Вы теряете этот бонус обстоятельства, " +
                "если больше не удовлетворяете требования способности.",
                Requirement = "Вы владеете двумя оружиями ближнего боя, по одному в каждой руке.",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { },
            },
            #endregion

            #region ChampionActions

            new DBAction
            {
                Name = "Divine grace",
                RussianName = "Божественная милость",
                Description = "Вы взываете к милости вашего божества, получая бонус " +
                "обстоятельства +2 к этому спасброску.",
                Requirement = "",
                Trigger = "Вы совершаете спасбросок против заклинания, но еще не " +
                "сделали бросок.",
                Type = ActionType.Reaction,
                Traits = new List<ActionTraits>() { },
            },
            new DBAction
            {
                Name = "Mercy",
                RussianName = "Милосердие",
                Description = "Ваше прикосновение снимает страх и восстанавливает движение. " +
                "Если ваше следующее действие - использование Наложение рук, помимо других " +
                "преимуществ, вы можете попытаться противодействовать эффекту страха или " +
                "эффекту наложившему на цель состояние парализован.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Concentrate,
                    ActionTraits.Metamagic
                }
            },
            #endregion

            #region AlchemistActions

            new DBAction
            {
                Name = "Quick bomber",
                RussianName = "Быстрый бомбометатель",
                Description = "Вы храните свои бомбы в легкодоступных мешочках, из которых не " +
                "задумываясь достаете их. Вы используете Взаимодействовать, чтобы достать бомбу " +
                "и потом Бросаете ее.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits> { }
            },
            #endregion

            #region WizardActions   

            new DBAction
            {
                Name = "Counterspell",
                RussianName = "Контрзаклинание",
                Description = "Когда враг Сотворяет заклинание, которое вы знаете, и вы можете видеть " +
                "его проявления, то можете использовать свою магию, чтобы противостоять ему. Вы " +
                "расходуете подготовленное заклинание, чтобы противостоять существу, творящему это же " +
                "заклинание. Вы теряете свой слот заклинания, как если бы сотворили спровоцировавшее " +
                "заклинание. Потом вы пытаетесь противодействовать спровоцировавшему заклинанию.",
                Requirement = "",
                Trigger = "Существо Сотворяет подготовленное вами заклинание.",
                Type = ActionType.Reaction,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Arcana,
                    ActionTraits.Abjuration
                }
            },
            new DBAction
            {
                Name = "Reach spell",
                RussianName = "Досягаемое заклинание",
                Description = "Вы можете увеличить дистанцию своих заклинаний. Если ваше следующее " +
                "действие - Сотворение заклинания, у которого есть дистанция, увеличьте дистанцию " +
                "заклинания на 30 футов. Как обычно при увеличении дистанций заклинания, если оно " +
                "имеет дистанцию касания, то вы увеличиваете его дистанцию до 30 футов.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Metamagic,
                    ActionTraits.Concentrate
                }
            },
            new DBAction
            {
                Name = "Widen spell",
                RussianName = "Расширенное заклинание",
                Description = "Вы управляете энергией заклинания, заставляя его воздействовать на " +
                "область шире обычного. Если ваше следующее действие - Сотворение заклинания, у " +
                "которого есть область взрыва, конуса или линии, и оно не имеет продолжительности, " +
                "то увеличьте область этого заклинания. Добавьте 5 футов к радиусу взрыва, который " +
                "обычно имеет радиус хотя бы 10 футов (не имеет эффекта на взрыв с меньшим радиусом). " +
                "Добавьте 5 футов к длине конуса или линии, которые обычно имеют длину 15 футов или " +
                "менее, и добавьте 10 футов к длине бо́льшего конуса и линии.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Metamagic,
                    ActionTraits.Manipulate
                }
            },
            new DBAction
            {
                Name = "Conceal spell",
                RussianName = "Скрыть заклинание",
                Description = "Скрывая свои жесты и магические формулы другими речами и движениями, " +
                "вы пытаетесь скрыть тот факт, что вы делаете Сотворение заклинания. Если " +
                "следующее действие - Сотворение заклинания, сделайте проверку Скрытности против " +
                "КС Восприятия одного или нескольких наблюдателей; если заклинание имеет словесные " +
                "компоненты, вы еще должны сделать проверку Обмана против КС Восприятия наблюдателей. " +
                "Если вы успешно прошли проверку (или проверки) против КС наблюдателя, этот " +
                "наблюдатель не замечает, что вы сотворяете заклинание, хотя материальные, жестовые " +
                "и словесные компоненты обычно заметны и заклинания обычно имеют сенсорные проявления, " +
                "которые сделали бы колдовство очевидным для тех, кто рядом. Это умение скрывает " +
                "только заклинательские действия и проявления, а не его эффекты, так что наблюдатель " +
                "все равно может увидеть исходящий от вас луч, или увидеть, как вы растворяетесь в воздухе.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Single,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Metamagic,
                    ActionTraits.Manipulate,
                    ActionTraits.Concentrate
                }
            },
            new DBAction
            {
                Name = "Bespell weapon",
                RussianName = "Околдованное оружие",
                Description = "Вы наполняете одно оружие, которым владеете, остаточной энергией последнего " +
                "сотворенного заклинания. До конца вашего хода, оружие наносит дополнительные 1d6 урона, тип " +
                "которого зависит от школы только что сотворенного заклинания. Преграждение: урон силой, " +
                "Воплощение или Трансмутация: тот же тип урона, что и у оружия, Прорицание, Очарование или " +
                "Иллюзия: ментальный урон, Эвокация: тип наносимый заклинанием, или силой, если заклинание " +
                "не наносит урон, Некромантия: негативный урон.",
                Requirement = "Ваше предыдущее действие - Сотворение заклинания, не являющееся чарами.",
                Trigger = "",
                Type = ActionType.Free,
                Traits = new List<ActionTraits> { }
            },
            new DBAction
            {
                Name = "Silent spell",
                RussianName = "Тихое заклинание",
                Description = "Вы научились как сотворять многие из своих заклинаний не произнося слов силы, " +
                "которые обычно требуются. Если ваше следующее действие - Сотворение заклинания, которое имеет " +
                "словесную компоненту и как минимум одну другую компоненту, то вы можете убрать словесную " +
                "компоненту. Это делате заклинание тихим и позволяет вам колдовать его в тех местах, где нет " +
                "звуков. Однако, заклинание все еще имеет визуальные проявления, так что это не делает его менее " +
                "очевидным для кого-то, кто видит как вы его творите. Когда вы используете Тихое заклинание, то " +
                "можете выбрать преимущества Скрыть заклинание, и вам не требуется проходить проверку Обмана, " +
                "потому что заклинание не имеет словесных компонент.",
                Requirement = "",
                Trigger = "",
                Type = ActionType.Free,
                Traits = new List<ActionTraits>
                {
                    ActionTraits.Metamagic,
                    ActionTraits.Concentrate
                }
            }
            #endregion

            );
            #endregion

        }
    }
}
