namespace Model.Creation.Strategies
{
    using DataBaseAccess.CoreBook.Types;
    using Model.Editor;
    using Model.LevelManager;

    /// <summary>
    /// Класс задающий значения Воина создаваемому персонажу.
    /// </summary>
    public class FighterStrutegy : IClassStrategy
    {
        /// <summary>
        /// Метод задаёт значения класса воина в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetClassInfo(Character character)
        {
            var service = new CreationGeneralInfoService();

            character.LevelManager = new FighterLevelManager();

            character.Editor = new FighterEditor();

            character.Info.General.ClassName = ClassType.Fighter;

            character.Info.CreationInfo.ClassOptionAbility = [AbilityType.Strength, AbilityType.Dexterity];

            character.Info.Stats.Skills[(int)SkillType.Perception]
                = ProficientyType.Expert;

            service.SetHealthPoints(character.Info, 10);

            service.SetSavingThrows(character.Info,
                                    ProficientyType.Expert,
                                    ProficientyType.Expert,
                                    ProficientyType.Trained);

            service.SetWeaponProficienty(character.Info,
                                        ProficientyType.Expert,
                                        ProficientyType.Expert,
                                        ProficientyType.Expert,
                                        ProficientyType.Trained);

            service.SetArmorProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained);

            character.Info.CreationInfo.SkillsCount += 2;

            character.Info.ItemNames.AddRange( new List<string>
                                {
                                    "Hide",
                                    "Dagger",
                                    "Adventurer's Pack",
                                    "Grappling hook",
                                });
        }
    }
}
