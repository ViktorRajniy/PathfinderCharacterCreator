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
        public void SetAncestriesInfo(DBCharacter character, HaritageType haritage, CreationInfo info)
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

            if (haritage == HaritageType.CavernElf)
            {
                service.SetFeat(character, info, "Cavern elf");
            }
            else
            {
                service.SetFeat(character, info, "Low-light vision");
            }

            if (haritage == HaritageType.WoodlandElf)
            {
                service.SetFeat(character, info, "Woodland elf");
            }

            info.AllowAncestoryAbility =
                [
                AbilityType.Strength,
                AbilityType.Wisdom,
                AbilityType.Charisma
            ];
        }
    }
}
