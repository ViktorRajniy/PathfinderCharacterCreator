﻿namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Чемпиона создаваемому персонажу.
    /// </summary>
    public class ChampionStrategy : IClassStrategy
    {
        /// <summary>
        /// Метод задаёт значения класса чемпиона в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetClassInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.ClassName = ClassType.Champion;

            character.CreationInfo.ClassAbility = [AbilityType.Strength, AbilityType.Dexterity];

            character.Stats.Skills[(int)SkillType.Perception]
                = ProficientyType.Trained;

            service.SetHealthPoints(character, 10);

            service.SetSavingThrows(character,
                                    ProficientyType.Expert,
                                    ProficientyType.Trained,
                                    ProficientyType.Expert);

            service.SetWeaponProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Untrained);

            service.SetArmorProficienty(character,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained,
                                        ProficientyType.Trained);

            character.CreationInfo.SkillsCount += 2;

            character.ItemNames.AddRange(new List<string>
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
