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
        public void SetClassInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.ClassName = ClassType.Alchemist;

            character.Stats.Abilities[(int)AbilityType.Intelligence] += 2;

            character.Stats.Skills[(int)SkillType.Perception] = ProficientyType.Trained;

            service.SetHealthPoints(character, 8);

            service.SetSavingThrows(character,
                                    ProficientyType.Expert,
                                    ProficientyType.Expert,
                                    ProficientyType.Trained);

            service.SetWeaponProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained,
                                        ProficientyType.Untrained);

            service.SetArmorProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained);

            character.CreationInfo.ClassSkillsCount += 2;

            character.ItemNames.AddRange(new List<string>
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
