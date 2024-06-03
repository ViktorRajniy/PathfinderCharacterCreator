namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
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
        public void SetClassInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.ClassName = ClassType.Fighter;

            character.CreationInfo.ClassOptionAbility = [AbilityType.Strength, AbilityType.Dexterity];

            character.Stats.Skills[(int)SkillType.Perception]
                = ProficientyType.Expert;

            service.SetHealthPoints(character, 10);

            service.SetSavingThrows(character,
                                    ProficientyType.Expert,
                                    ProficientyType.Expert,
                                    ProficientyType.Trained);

            service.SetWeaponProficienty(character,
                                        ProficientyType.Expert,
                                        ProficientyType.Expert,
                                        ProficientyType.Expert,
                                        ProficientyType.Trained);

            service.SetArmorProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained);

            character.CreationInfo.SkillsCount += 2;

            character.ItemNames.AddRange( new List<string>
                                {
                                    "Hide",
                                    "Dagger",
                                    "Adventurer's Pack",
                                    "Grappling hook",
                                });
        }
    }
}
