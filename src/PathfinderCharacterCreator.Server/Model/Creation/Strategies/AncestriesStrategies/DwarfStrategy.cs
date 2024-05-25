namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Дварфа создаваемому персонажу.
    /// </summary>
    public class DwarfStrategy : IAncestriesStrategy
    {
        /// <summary>
        /// Метод задаёт значения родословной дварфа в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetAncestriesInfo(DBCharacter character, HaritageType haritage, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.General.Ancestry = AncestryType.Dwarf;

            service.SetHealthPoints(character, 10);

            service.SetAbility(character,
                                AbilityType.Constitution,
                                AbilityType.Wisdom,
                                AbilityType.Charisma);

            character.General.Size = SizeType.Medium;

            character.Stats.Speed = 20;

            character.ItemNames.AddRange(new List<string>
                                {
                                    "Clan Dagger"
                                });

            if (haritage == HaritageType.AncientBloodedDwarf)
            {
                service.SetFeat(character, info, "Ancient-blooded dwarf");
            }

            if (haritage == HaritageType.DeathWardenDwarf)
            {
                service.SetFeat(character, info, "Death warden dwarf");
            }

            info.AllowAncestoryAbility =
                [
                AbilityType.Strength,
                AbilityType.Dexterity,
                AbilityType.Intelligence
            ];
        }
    }
}
