namespace DataBaseAccess.CoreBook.Feats
{
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Список всех черт.
    /// </summary>
    public class AllFeats
    {
        /// <summary>
        /// Объект AllFeats.
        /// </summary>
        private static AllFeats _instance;

        /// <summary>
        /// Локер.
        /// </summary>
        private static readonly object _locker = new object();

        /// <summary>
        /// Список всех черт Pathfinder 2e.
        /// </summary>
        public List<FeatBase> Feats { get; set; }

        /// <summary>
        /// Метод создающий объект AllFeats.
        /// </summary>
        /// <returns>Объект AllFeats.</returns>
        public static AllFeats Instance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new AllFeats();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        private AllFeats()
        {
            Feats = new List<FeatBase>()
            {
                #region BaseFeats

                new FeatBase()
                {
                    Name = "Night vision",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Low-light vision",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Ancient-blooded dwarf",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.AncientBloodedDwarf;
                    },
                    Assign = (info) =>
                    {
                        info.ActionNames.Add("Call on ancient blood");
                    },
                },
                new FeatBase()
                {
                    Name = "Death warden dwarf",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.DeathWardenDwarf;
                    },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Unbreakable goblin",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.UnbreakableGoblin;
                    },
                    Assign = (info) =>
                    {
                        info.Stats.CurrentHealthPoints +=4;
                        info.Stats.MaxHealthPoints +=4;
                    },
                },
                new FeatBase()
                {
                    Name = "Razortooth goblin",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.RazortoothGoblin;
                    },
                    Assign = (info) =>
                    {
                        // TODO Атака зубами.
                    },
                },
                new FeatBase()
                {
                    Name = "Cavern elf",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.CavernElf;
                    },
                    Assign = (info) =>
                    {
                        info.FeatNames.Add("Night vision");
                    },
                },
                new FeatBase()
                {
                    Name = "Woodland elf",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.WoodlandElf;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Skilled heritage",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.SkilledHeritage;
                    },
                    Assign = (info) =>
                    {
                        info.CreationInfo.ClassSkillsCount++;
                    },
                },
                new FeatBase()
                {
                    Name = "Versatile heritage",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return info.General.Haritage == HaritageType.VersatileHeritage;
                    },
                    Assign = (info) =>
                    {
                        info.CreationInfo.GeneralFeatCount++;
                    },
                },

                #endregion

                #region GeneralFeats

                #region Level1

                new FeatBase()
                {
                    Name = "Armor proficiency",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) =>
                    {
                        bool lightUnrained =
                        info.Stats.ArmorProficienty[(int)ArmorType.Light]
                        == ProficientyType.Untrained;

                        bool mediumUnrained =
                        info.Stats.ArmorProficienty[(int)ArmorType.Medium]
                        == ProficientyType.Untrained;

                        bool heavyUnrained =
                        info.Stats.ArmorProficienty[(int)ArmorType.Heavy]
                        == ProficientyType.Untrained;

                        if(lightUnrained)
                        {
                            info.Stats.ArmorProficienty[(int)ArmorType.Light]
                            = ProficientyType.Trained;
                            return;
                        }
                        if(mediumUnrained)
                        {
                            info.Stats.ArmorProficienty[(int)ArmorType.Medium]
                            = ProficientyType.Trained;
                            return;
                        }
                        if(heavyUnrained)
                        {
                            info.Stats.ArmorProficienty[(int)ArmorType.Heavy]
                            = ProficientyType.Trained;
                            return;
                        }
                    },
                },
                new FeatBase()
                {
                    Name = "Breath control",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Canny acumen - Perception",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Perception]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) =>
                    {
                        info.Stats.Skills[(int)SkillType.Perception]
                        = ProficientyType.Expert;
                    },
                },
                new FeatBase()
                {
                    Name = "Canny acumen - Fortitude",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.SavingThrows[(int)SavingThrowType.Fortitude]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) =>
                    {
                        info.Stats.SavingThrows[(int)SavingThrowType.Fortitude]
                        = ProficientyType.Expert;
                    },
                },
                new FeatBase()
                {
                    Name = "Canny acumen - Reflex",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.SavingThrows[(int)SavingThrowType.Reflex]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) =>
                    {
                        info.Stats.SavingThrows[(int)SavingThrowType.Reflex]
                        = ProficientyType.Expert;
                    },
                },
                new FeatBase()
                {
                    Name = "Canny acumen - Will",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.SavingThrows[(int)SavingThrowType.Will]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) =>
                    {
                        info.Stats.SavingThrows[(int)SavingThrowType.Will]
                        = ProficientyType.Expert;
                    },
                },
                new FeatBase()
                {
                    Name = "Diehard",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Feather step",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => { return info.Stats.Abilities[(int)AbilityType.Dexterity] >= 14; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Fast recovery",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => { return info.Stats.Abilities[(int)AbilityType.Constitution] >= 14; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Fleet",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Abilities[(int)AbilityType.Dexterity] >= 14;
                    },
                    Assign = (info) =>
                    {
                        info.Stats.Speed += 5;
                    },
                },
                new FeatBase()
                {
                    Name = "Incredeble initiative",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => {return true; },
                    Assign = (info) => {}
                },
                new FeatBase()
                {
                    Name = "Shield block",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => {return true; },
                    Assign = (info) =>
                    {
                        info.ActionNames.Add("Shield block");
                    }
                },
                new FeatBase()
                {
                    Name = "Toughness",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => {return true; },
                    Assign = (info) =>
                    {
                        info.Stats.MaxHealthPoints += info.Level;
                    }
                },
                new FeatBase()
                {
                    Name = "Weapon proficiency",
                    Type = FeatType.General,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) =>
                    {
                        bool simpleUnrained =
                        info.Stats.WeaponProficienty[(int)WeaponType.Simple]
                        == ProficientyType.Untrained;

                        bool martialUnrained =
                        info.Stats.WeaponProficienty[(int)WeaponType.Martial]
                        == ProficientyType.Untrained;

                        bool advancedUnrained =
                        info.Stats.WeaponProficienty[(int)WeaponType.Advanced]
                        == ProficientyType.Untrained;

                        if(simpleUnrained)
                        {
                        info.Stats.WeaponProficienty[(int)WeaponType.Simple]
                            = ProficientyType.Trained;
                            return;
                        }
                        if(martialUnrained)
                        {
                        info.Stats.WeaponProficienty[(int)WeaponType.Martial]
                            = ProficientyType.Trained;
                            return;
                        }
                        if(advancedUnrained)
                        {
                        info.Stats.WeaponProficienty[(int)WeaponType.Advanced]
                            = ProficientyType.Trained;
                            return;
                        }
                    },
                },

                #endregion

                #region Level3

                            new FeatBase
                            {
                                Name = "Ancestral paragon",
                                Type = FeatType.General,
                                Level = 3,
                                CanAssign = (info) => { return info.Level >= 3; },
                                Assign = (info) =>
                                {
                                    info.CreationInfo.AncestoryFeatCount++;
                                }
                            },
                            new FeatBase
                            {
                                Name = "Untrained improvisation",
                                Type = FeatType.General,
                                Level = 3,
                                CanAssign = (info) => { return info.Level >= 3; },
                                Assign = (info) => { }
                            },

                            #endregion

                #region Level7

                            new FeatBase
                            {
                                Name = "Expeditious search",
                                Type = FeatType.General,
                                Level = 7,
                                CanAssign = (info) => { return info.Level >= 7; },
                                Assign = (info) => { }
                            },

                            #endregion

                #region Level11

                            new FeatBase
                            {
                                Name = "Incredible investiture",
                                Type = FeatType.General,
                                Level = 11,
                                CanAssign = (info) =>
                                {
                                    return info.Level >= 11 &&
                                    info.Stats.Abilities[(int)AbilityType.Charisma] >=16;
                                },
                                Assign = (info) => { }
                            },

                            #endregion

                #region Level19



                            #endregion

                #endregion
                
                #region SkillFeats

                #region VaryingSkillFeats

                new FeatBase()
                {
                    Name = "Dubious knowledge",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Arcana]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Crafting]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Medicine]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Nature]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Occultism]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Religion]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Society]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Quick identification",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Arcana]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Nature]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Occultism]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Religion]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Recognize spell",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Arcana]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Nature]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Occultism]
                        == ProficientyType.Trained ||
                        info.Stats.Skills[(int)SkillType.Religion]
                        == ProficientyType.Trained;
                    },
                    Assign = (info) =>
                    {
                        // TODO
                        // info.Actions.Add(new Action()
                        // {
                        //     Name = "Recognize spell",
                        //     Type = Enums.ActionType.Reaction,
                        //     Traits = new List<Enums.ActionTraits> { Enums.ActionTraits.Secret }
                        // });
                    },
                },
                new FeatBase()
                {
                    Name = "Skill training",
                    Type = FeatType.Base,
                    Level = 1,
                    CanAssign = (info) => { return true; },
                    Assign = (info) =>
                    {
                        info.CreationInfo.ClassSkillsCount++;
                    },
                },

                #endregion

                #region AcrobaticsSkillFeats

                            new FeatBase()
                            {
                                Name = "Cat fall",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Quick squeeze",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Steady balance",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Acrobatic performer",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Nimble crawl",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Acrobatics] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Kip up",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Acrobatics] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Aerobatics mastery",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Acrobatics] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Acrobatics] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region ArcanaSkillFeats

                            new FeatBase()
                            {
                                Name = "Arcane sense",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Arcana] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Unified theory",
                                Type = FeatType.Skill,
                                Level = 15,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Arcana] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region AthleticsSkillFeats

                            new FeatBase()
                            {
                                Name = "Combat climber",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Hefty hauler",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) =>
                                {
                                    // Максимальный перегруз +2
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Quick jump",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Titan wrestler",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Underwater marauder",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Powerful leap",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Rapid mantel",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Lead climber",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Athletics] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Quick climb",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Athletics] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Quick swim",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Athletics] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                            new FeatBase()
                            {
                                Name = "Wall jump",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Athletics] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Athletics] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region CraftingSkillFeats

                new FeatBase()
                            {
                                Name = "Alchemical crafting",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Quick repair",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Snare crafting",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Crafters appraisal",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Improvise tool",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Magical crafting",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Tattoo artist",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Inventor",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Crafting] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Rapid affixture",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Crafting] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Craft anything",
                                Type = FeatType.Skill,
                                Level = 15,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Crafting] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region DeceptionSkillFeats
                
                new FeatBase()
                            {
                                Name = "Charming liar",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Lengthy diversion",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Lie to me",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Charlatan",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Confabulator",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Quick disguese",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Deception] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Slippery secrets",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Deception] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Doublespeak",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Deception] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Deception] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region DiplomacySkillFeats

                new FeatBase()
                            {
                                Name = "Bargain hunter",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Diplomacy] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Group impression",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Diplomacy] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Hobnobber",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Diplomacy] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Glad-hand",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Diplomacy] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Diplomacy] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Shameless request",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Diplomacy] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Diplomacy] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Legendary negotiation",
                                Type = FeatType.Skill,
                                Level = 15,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Diplomacy] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region IntimidationSkillFeats
                
                new FeatBase()
                            {
                                Name = "Group coercion",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Intimidating glare",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Quick coercion",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Intimidating prowess",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    (info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Trained) &&
                                    info.Stats.Abilities[(int)AbilityType.Strength] == 16;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Lasting coercion",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Terrifying resistance",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Intimidation] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Battle cry",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Intimidation] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Terrified retreat",
                                Type = FeatType.Skill,
                                Level = 7,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Intimidation] ==
                                    ProficientyType.Master ||
                                    info.Stats.Skills[(int)SkillType.Intimidation] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region LoreSkillFeats
                
                new FeatBase()
                            {
                                Name = "Additional lore",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Lore] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Experienced professional",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Lore] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Unmastalable lore",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Lore] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Lore] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Legendary professional",
                                Type = FeatType.Skill,
                                Level = 15,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Lore] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region MedicineSkillFeats

                new FeatBase()
                            {
                                Name = "Battle medicine",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) =>
                                {
                                    // TODO Action Лечение ран в бою.
                                },
                            },
                new FeatBase()
                            {
                                Name = "Continual recovery",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Robust recovery",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Ward medic",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Medicine] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Legendary medic",
                                Type = FeatType.Skill,
                                Level = 15,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Medicine] ==
                                    ProficientyType.Legend;
                                },
                                Assign = (info) => { },
                            },
                #endregion

                #region NatureSkillFeats
                
                new FeatBase()
                            {
                                Name = "Natural medicine",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Nature] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Train animal",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Nature] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                            {
                                Name = "Bonded animal",
                                Type = FeatType.Skill,
                                Level = 2,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Nature] !=
                                    ProficientyType.Untrained &&
                                    info.Stats.Skills[(int)SkillType.Nature] !=
                                    ProficientyType.Trained;
                                },
                                Assign = (info) => { },
                            },

                #endregion

                #region OccultismSkillFeats
                
                new FeatBase()
                            {
                                Name = "Oddity identification",
                                Type = FeatType.Skill,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return
                                    info.Stats.Skills[(int)SkillType.Occultism] !=
                                    ProficientyType.Untrained;
                                },
                                Assign = (info) => { },
                            },
                new FeatBase()
                {
                    Name = "Bizarre magic",
                    Type = FeatType.Skill,
                    Level = 7,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Occultism] ==
                        ProficientyType.Master ||
                        info.Stats.Skills[(int)SkillType.Occultism] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },

                #endregion

                #region PerformanceSkillFeats
                
                new FeatBase()
                {
                    Name = "Fascinating performance",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Performance] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Impressive performance",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Performance] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Vertuosic performer",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Performance] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Legendary performer",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Performance] ==
                        ProficientyType.Legend &&
                        info.FeatNames.Contains("Vertuosic performer");
                    },
                    Assign = (info) => { },
                },

                #endregion

                #region ReligionSkillFeats

                new FeatBase()
                {
                    Name = "Student of the canon",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Religion] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Divine guidance",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Religion] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },

                #endregion

                #region SocietySkillFeats
                
                new FeatBase()
                {
                    Name = "Courtly graces",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Multilingual",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Read lips",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Sign language",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Streetwise",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Legendary codebreaker",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Legendary linguist",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Society] ==
                        ProficientyType.Legend &&
                        info.FeatNames.Contains("Multilingual");
                    },
                    Assign = (info) => { },
                },

                #endregion

                #region StealthSkillFeats

                new FeatBase()
                {
                    Name = "Experienced smuggler",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Stealth] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Terrain stalker",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Stealth] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Quiet allies",
                    Type = FeatType.Skill,
                    Level = 2,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Stealth] !=
                        ProficientyType.Untrained &&
                        info.Stats.Skills[(int)SkillType.Stealth] !=
                        ProficientyType.Trained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Foil senses",
                    Type = FeatType.Skill,
                    Level = 7,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Stealth] ==
                        ProficientyType.Master ||
                        info.Stats.Skills[(int)SkillType.Stealth] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Swift sneak",
                    Type = FeatType.Skill,
                    Level = 7,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Stealth] ==
                        ProficientyType.Master ||
                        info.Stats.Skills[(int)SkillType.Stealth] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Legendary sneak",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Stealth] ==
                        ProficientyType.Legend &&
                        info.FeatNames.Contains("Swift sneak");
                    },
                    Assign = (info) => { },
                },

                #endregion

                #region SurvivalSkillFeats
                
                new FeatBase()
                {
                    Name = "Experienced tracker",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Survival] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Forager",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Survival] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Survey wildlife",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Survival] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Terrain expertise",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Survival] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Planar survival",
                    Type = FeatType.Skill,
                    Level = 7,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Survival] ==
                        ProficientyType.Master ||
                        info.Stats.Skills[(int)SkillType.Survival] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Legendary survivalist",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Survival] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },

                #endregion

                #region ThieverySkillFeats
                
                new FeatBase()
                {
                    Name = "Pickpocket",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Thievery] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Subtle theft",
                    Type = FeatType.Skill,
                    Level = 1,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Thievery] !=
                        ProficientyType.Untrained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Wary disarmament",
                    Type = FeatType.Skill,
                    Level = 2,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Thievery] !=
                        ProficientyType.Untrained &&
                        info.Stats.Skills[(int)SkillType.Thievery] !=
                        ProficientyType.Trained;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Quick unlock",
                    Type = FeatType.Skill,
                    Level = 7,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Thievery] ==
                        ProficientyType.Master ||
                        info.Stats.Skills[(int)SkillType.Thievery] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },
                new FeatBase()
                {
                    Name = "Legendary thief",
                    Type = FeatType.Skill,
                    Level = 15,
                    CanAssign = (info) =>
                    {
                        return
                        info.Stats.Skills[(int)SkillType.Thievery] ==
                        ProficientyType.Legend;
                    },
                    Assign = (info) => { },
                },

                #endregion

                #endregion

                #region AncestriesFeats

                #region DwarfFeats
                
                new FeatBase()
                {
                    Name = "Dwarven lore",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                    Assign = (info) =>
                    {
                        if(info.Stats.Skills[(int)SkillType.Crafting] == ProficientyType.Untrained)
                        {
                            info.Stats.Skills[(int)SkillType.Crafting] = ProficientyType.Trained;
                        }
                        else
                        {
                            info.CreationInfo.ClassSkillsCount++;
                        }
                        if(info.Stats.Skills[(int)SkillType.Religion] == ProficientyType.Untrained)
                        {
                            info.Stats.Skills[(int)SkillType.Religion] = ProficientyType.Trained;
                        }
                        else
                        {
                            info.CreationInfo.ClassSkillsCount++;
                        }
                    }
                },
                new FeatBase()
                {
                    Name = "Dwarven weapon familiarity",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Rock runner",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Stonecunning",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Unburned iron",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Vengeful hatred",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                    Assign = (info) => {},
                },

                #endregion

                #region GoblinFeats
                
                new FeatBase()
                {
                    Name = "Burn it",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Goblin; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "City scavenger",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Goblin; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Goblin lore",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Goblin; },
                    Assign = (info) =>
                    {
                        if(info.Stats.Skills[(int)SkillType.Nature] == ProficientyType.Untrained)
                        {
                            info.Stats.Skills[(int)SkillType.Nature] = ProficientyType.Trained;
                        }
                        else
                        {
                            info.CreationInfo.ClassSkillsCount++;
                        }
                        if(info.Stats.Skills[(int)SkillType.Stealth] == ProficientyType.Untrained)
                        {
                            info.Stats.Skills[(int)SkillType.Stealth] = ProficientyType.Trained;
                        }
                        else
                        {
                            info.CreationInfo.ClassSkillsCount++;
                        }
                    },
                },

                #endregion

                #region ElfFeats
                
                new FeatBase()
                {
                    Name = "Elven lore",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                    Assign = (info) =>
                    {
                        if(info.Stats.Skills[(int)SkillType.Arcana] == ProficientyType.Untrained)
                        {
                            info.Stats.Skills[(int)SkillType.Arcana] = ProficientyType.Trained;
                        }
                        else
                        {
                            info.CreationInfo.ClassSkillsCount++;
                        }
                        if(info.Stats.Skills[(int)SkillType.Nature] == ProficientyType.Untrained)
                        {
                            info.Stats.Skills[(int)SkillType.Nature] = ProficientyType.Trained;
                        }
                        else
                        {
                            info.CreationInfo.ClassSkillsCount++;
                        }
                    },
                },
                new FeatBase()
                {
                    Name = "Forlorn",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Nimble elf",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                    Assign = (info) => { info.Stats.Speed += 5; },
                },
                new FeatBase()
                {
                    Name = "Unwavering mien",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                    Assign = (info) => {},
                },

                #endregion

                #region HumanFeats
                                
                new FeatBase()
                {
                    Name = "Cooperative nature",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Human; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Cooperative nature",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Human; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "General Training",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Human; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Haughty obstinacy",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Human; },
                    Assign = (info) => {},
                },
                new FeatBase()
                {
                    Name = "Natural ambition",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Human; },
                    Assign = (info) =>
                    {
                        info.CreationInfo.ClassFeatCount++;
                    },
                },
                new FeatBase()
                {
                    Name = "Natural skill",
                    Type = FeatType.Ancestory,
                    Level = 1,
                    CanAssign = (info) => { return info.General.Ancestry == AncestryType.Human; },
                    Assign = (info) =>
                    {
                        info.CreationInfo.ClassSkillsCount += 2;
                    },
                },

                #endregion

                #endregion

                #region ClassFeats

                #region FighterFeats

                #region Level1

                new FeatBase()
                            {
                                Name = "Double slice",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Double slice",
                                    //     Type = Enums.ActionType.TwoActions,
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Exacting strike",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Double slice",
                                    //     Type = Enums.ActionType.SingleAction,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    //     {
                                    //         Enums.ActionTraits.Press,
                                    //     }
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Point-blank shot",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Point-blank shot",
                                    //     Type = Enums.ActionType.SingleAction,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    //     {
                                    //         Enums.ActionTraits.Press,
                                    //         Enums.ActionTraits.Stance,
                                    //     }
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Power attack",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Power attack",
                                    //     Type = Enums.ActionType.TwoActions,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    //     {
                                    //         Enums.ActionTraits.Flourish,
                                    //     }
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Reactive shield",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Reactive shield",
                                    //     Type = Enums.ActionType.Reaction,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Snagging strike",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Snagging strike",
                                    //     Type = Enums.ActionType.SingleAction,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Sudden charge (Fighter)",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Sudden charge (Fighter)",
                                    //     Type = Enums.ActionType.TwoActions,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    //     {
                                    //         Enums.ActionTraits.Open,
                                    //         Enums.ActionTraits.Flourish,
                                    //     }
                                    // });
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Combat assessment",
                                Type = FeatType.Class,
                                Level = 1,
                                CanAssign = (info) =>
                                {
                                    return info.General.ClassName == ClassType.Fighter;
                                },
                                Assign = (info) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new Action()
                                    // {
                                    //     Name = "Combat assessment",
                                    //     Type = Enums.ActionType.SingleAction,
                                    //     Traits = new List<Enums.ActionTraits>()
                                    // });
                                },
                            },

                            #endregion

                            #endregion

                            #endregion
            };
        }
    }
}
