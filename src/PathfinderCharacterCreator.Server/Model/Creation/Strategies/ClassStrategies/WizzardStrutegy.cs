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
        public void SetClassInfo(Character character, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.LevelManager = new WizzardLevelManager();

            character.Editor = new WizzardEditor();

            character.Info.General.ClassName = ClassType.Wizzard;

            character.Info.Stats.Abilities[(int)AbilityType.Intelligence] += 2;

            character.Info.Stats.Skills[(int)SkillType.Perception]
                = ProficientyType.Trained;

            service.SetHealthPoints(character.Info, 6);

            service.SetSavingThrows(character.Info,
                                    ProficientyType.Trained,
                                    ProficientyType.Trained,
                                    ProficientyType.Expert);

            service.SetWeaponProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained);

            service.SetArmorProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained);

            info.SkillsCount += 2;

            character.Info.ItemNames.AddRange(new List<string>
                                {
                                    "Staff",
                                    "Writting set",
                                    "Adventurer's Pack",
                                    "Material component pouch",
                                });
        }
    }
}
