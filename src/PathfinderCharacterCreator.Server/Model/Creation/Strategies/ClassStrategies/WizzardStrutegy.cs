namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;
    using Model.Editor;
    using Model.LevelManager;

    public class WizzardStrutegy : IClassStrategy
    {
        /// <summary>
        /// Метод задаёт значения класса воина в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetClassInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.ClassName = ClassType.Wizzard;

            character.Stats.Abilities[(int)AbilityType.Intelligence] += 2;

            character.Stats.Skills[(int)SkillType.Perception]
                = ProficientyType.Trained;

            service.SetHealthPoints(character, 6);

            service.SetSavingThrows(character,
                                    ProficientyType.Trained,
                                    ProficientyType.Trained,
                                    ProficientyType.Expert);

            service.SetWeaponProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained);

            service.SetArmorProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained);

            character.CreationInfo.SkillsCount += 2;

            character.ItemNames.AddRange(new List<string>
                                {
                                    "Staff",
                                    "Writting set",
                                    "Adventurer's Pack",
                                    "Material component pouch",
                                });
        }
    }
}
