namespace Model.Creation.Strategies
{
    using DataBaseAccess.CoreBook.Types;
    using Model.Editor;
    using Model.LevelManager;

    /// <summary>
    /// Класс задающий значения Алхимика создаваемому персонажу.
    /// </summary>
    public class AlchemistStrategy : IClassStrategy
    {
        /// <summary>
        /// Метод задаёт значения класса алхимика в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetClassInfo(Character character)
        {
            var service = new CreationGeneralInfoService();

            character.LevelManager = new AlchemistLevelManager();

            character.Editor = new AlchemistEditor();

            character.Info.General.ClassName = ClassType.Alchemist;

            character.Info.Stats.Abilities[(int)AbilityType.Intelligence] += 2;

            character.Info.Stats.Skills[(int)SkillType.Perception] = ProficientyType.Trained;

            service.SetHealthPoints(character.Info, 8);

            service.SetSavingThrows(character.Info,
                                    ProficientyType.Expert,
                                    ProficientyType.Expert,
                                    ProficientyType.Trained);

            service.SetWeaponProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained);

            service.SetArmorProficienty(character.Info,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained);

            character.Info.CreationInfo.SkillsCount += 2;

            character.Info.ItemNames.AddRange(new List<string>
                                {
                                    "Studded Leather",
                                    "Dagger",
                                    "Sling",
                                    "Sling bullets",
                                    "Adventurer's Pack",
                                    "Alchemist's Tools",
                                    "Basic Crafter's Book",
                                    "Caltrops",
                                });
        }
    }
}
