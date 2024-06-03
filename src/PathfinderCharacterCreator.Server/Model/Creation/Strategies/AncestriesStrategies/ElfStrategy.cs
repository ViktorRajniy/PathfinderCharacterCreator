namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Эльфа создаваемому персонажу.
    /// </summary>
    public class ElfStrategy : IAncestriesStrategy
    {
        /// <summary>
        /// Метод задаёт значения родословной эльфа в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetAncestriesInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.Ancestry = AncestryType.Elf;

            service.SetHealthPoints(character, 6);

            service.SetAbility(character,
                                AbilityType.Dexterity,
                                AbilityType.Intelligence,
                                AbilityType.Constitution);

            character.General.Size = SizeType.Medium;

            character.Stats.Speed = 30;

            if (character.General.Haritage == HaritageType.CavernElf)
            {
                service.SetFeat(character, "Cavern elf");
            }
            else
            {
                service.SetFeat(character, "Low-light vision");
            }

            if (character.General.Haritage == HaritageType.WoodlandElf)
            {
                service.SetFeat(character, "Woodland elf");
            }

            character.CreationInfo.AncestoryAbility =
                [
                AbilityType.Strength,
                AbilityType.Wisdom,
                AbilityType.Charisma
            ];
        }
    }
}
