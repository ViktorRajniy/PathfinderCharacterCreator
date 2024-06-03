namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Гоблина создаваемому персонажу.
    /// </summary>
    public class GoblinStrategy : IAncestriesStrategy
    {
        /// <summary>
        /// Метод задаёт значения родословной гоблина в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetAncestriesInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.Ancestry = AncestryType.Goblin;

            service.SetAbility(character,
                                AbilityType.Dexterity,
                                AbilityType.Charisma,
                                AbilityType.Wisdom);

            character.General.Size = SizeType.Medium;

            service.SetHealthPoints(character, 6);

            if (character.General.Haritage == HaritageType.UnbreakableGoblin)
            {
                service.SetFeat(character, "Unbreakable goblin");
            };

            character.Stats.Speed = 25;

            if (character.General.Haritage == HaritageType.RazortoothGoblin)
            {
                service.SetFeat(character, "Razortooth goblin");
            };

            character.CreationInfo.AncestoryAbility =
                [
                AbilityType.Strength,
                AbilityType.Constitution,
                AbilityType.Intelligence
            ];
        }
    }
}
