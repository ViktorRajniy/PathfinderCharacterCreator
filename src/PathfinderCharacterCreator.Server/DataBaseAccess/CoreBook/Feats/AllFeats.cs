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
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Low-light vision",
                                Type = FeatType.Base,
                                Level = 1,
                                CanAssign = (info) => { return true; },
                                Assign = (info, creationInfo) => {},
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) => {},
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Feather step",
                                Type = FeatType.General,
                                Level = 1,
                                CanAssign = (info) => { return info.Stats.Abilities[(int)AbilityType.Dexterity] >= 14; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Fast recovery",
                                Type = FeatType.General,
                                Level = 1,
                                CanAssign = (info) => { return info.Stats.Abilities[(int)AbilityType.Constitution] >= 14; },
                                Assign = (info, creationInfo) => {},
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) => {}
                            },
                            new FeatBase()
                            {
                                Name = "Shield block",
                                Type = FeatType.General,
                                Level = 1,
                                CanAssign = (info) => {return true; },
                                Assign = (info, creationInfo) =>
                                {
                                    // TODO
                                    // info.Actions.Add(new DBAction()
                                    // {
                                         //Name = "Shield block",
                                         //Type = ActionType.Reaction
                                    // });
                                }
                            },
                            new FeatBase()
                            {
                                Name = "Toughness",
                                Type = FeatType.General,
                                Level = 1,
                                CanAssign = (info) => {return true; },
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
                                {
                                    creationInfo.AncestoryFeatCount++;
                                }
                            },
                            new FeatBase
                            {
                                Name = "Untrained improvisation",
                                Type = FeatType.General,
                                Level = 3,
                                CanAssign = (info) => { return info.Level >= 3; },
                                Assign = (info, creationInfo) => { }
                            },

                            #endregion

                            #region Level7

                            new FeatBase
                            {
                                Name = "Expeditious search",
                                Type = FeatType.General,
                                Level = 7,
                                CanAssign = (info) => { return info.Level >= 7; },
                                Assign = (info, creationInfo) => { }
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
                                Assign = (info, creationInfo) => { }
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
                                Assign = (info, creationInfo) => {},
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
                                Assign = (info, creationInfo) => {},
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
                                {
                                    creationInfo.SkillsCount++;
                                },
                            },

                            #endregion

                            #region AcrobaticsSkillFeats



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
                                Assign = (info, creationInfo) =>
                                {
                                    if(info.Stats.Skills[(int)SkillType.Crafting] == ProficientyType.Untrained)
                                    {
                                        info.Stats.Skills[(int)SkillType.Crafting] = ProficientyType.Trained;
                                    }
                                    else
                                    {
                                        creationInfo.SkillsCount++;
                                    }
                                    if(info.Stats.Skills[(int)SkillType.Religion] == ProficientyType.Untrained)
                                    {
                                        info.Stats.Skills[(int)SkillType.Religion] = ProficientyType.Trained;
                                    }
                                    else
                                    {
                                        creationInfo.SkillsCount++;
                                    }
                                }
                            },
                            new FeatBase()
                            {
                                Name = "Dwarven weapon familiarity",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Rock runner",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Stonecunning",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Unburned iron",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Vengeful hatred",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Dwarf; },
                                Assign = (info, creationInfo) => {},
                            },

                            #endregion

                            #region GoblinFeats

                            new FeatBase()
                            {
                                Name = "Burn it",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Goblin; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "City scavenger",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Goblin; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Goblin lore",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Goblin; },
                                Assign = (info, creationInfo) =>
                                {
                                    if(info.Stats.Skills[(int)SkillType.Nature] == ProficientyType.Untrained)
                                    {
                                        info.Stats.Skills[(int)SkillType.Nature] = ProficientyType.Trained;
                                    }
                                    else
                                    {
                                        creationInfo.SkillsCount++;
                                    }
                                    if(info.Stats.Skills[(int)SkillType.Stealth] == ProficientyType.Untrained)
                                    {
                                        info.Stats.Skills[(int)SkillType.Stealth] = ProficientyType.Trained;
                                    }
                                    else
                                    {
                                        creationInfo.SkillsCount++;
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
                                Assign = (info, creationInfo) =>
                                {
                                    if(info.Stats.Skills[(int)SkillType.Arcana] == ProficientyType.Untrained)
                                    {
                                        info.Stats.Skills[(int)SkillType.Arcana] = ProficientyType.Trained;
                                    }
                                    else
                                    {
                                        creationInfo.SkillsCount++;
                                    }
                                    if(info.Stats.Skills[(int)SkillType.Nature] == ProficientyType.Untrained)
                                    {
                                        info.Stats.Skills[(int)SkillType.Nature] = ProficientyType.Trained;
                                    }
                                    else
                                    {
                                        creationInfo.SkillsCount++;
                                    }
                                },
                            },
                            new FeatBase()
                            {
                                Name = "Forlorn",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                                Assign = (info, creationInfo) => {},
                            },
                            new FeatBase()
                            {
                                Name = "Nimble elf",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                                Assign = (info, creationInfo) => { info.Stats.Speed += 5; },
                            },
                            new FeatBase()
                            {
                                Name = "Unwavering mien",
                                Type = FeatType.Ancestory,
                                Level = 1,
                                CanAssign = (info) => { return info.General.Ancestry == AncestryType.Elf; },
                                Assign = (info, creationInfo) => {},
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
                                Assign = (info, creationInfo) =>
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
