namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;
    using Model.Editor;
    using Model.LevelManager;

    /// <summary>
    /// Класс задающий значения Чемпиона создаваемому персонажу.
    /// </summary>
    public class ChampionStrategy : IClassStrategy
    {
        /// <summary>
        /// Метод задаёт значения класса чемпиона в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetClassInfo(Character character, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.LevelManager = new ChampionLevelManager();

            character.Editor = new ChampionEditor();

            character.Info.General.ClassName = ClassType.Champion;

            info.OptionClassAbility = true;
            info.ClassOptionAbility = [AbilityType.Strength, AbilityType.Dexterity];

            character.Info.Stats.Skills[(int)SkillType.Perception]
                = ProficientyType.Trained;

            service.SetHealthPoints(character.Info, 10);

            service.SetSavingThrows(character.Info,
                                    ProficientyType.Expert,
                                    ProficientyType.Trained,
                                    ProficientyType.Expert);

            service.SetWeaponProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained);

            service.SetArmorProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained);

            info.SkillsCount += 2;

            character.Info.ItemNames.AddRange(new List<string>
                                {
                                    "Hide",
                                    "Dagger",
                                    "Javelin",
                                    "Javelin",
                                    "Javelin",
                                    "Javelin",
                                    "Adventurer's Pack",
                                    "Crowbar",
                                    "Grappling hook",
                                });
        }
    }
}
