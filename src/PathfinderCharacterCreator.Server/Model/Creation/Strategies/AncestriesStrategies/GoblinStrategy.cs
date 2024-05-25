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
        public void SetAncestriesInfo(DBCharacter character, HaritageType haritage, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.General.Ancestry = AncestryType.Goblin;

            service.SetAbility(character,
                                AbilityType.Dexterity,
                                AbilityType.Charisma,
                                AbilityType.Wisdom);

            character.General.Size = SizeType.Medium;

            service.SetHealthPoints(character, 6);

            if (haritage == HaritageType.UnbreakableGoblin)
            {
                service.SetFeat(character, info, "Unbreakable goblin");
            };

            character.Stats.Speed = 25;

            if (haritage == HaritageType.RazortoothGoblin)
            {
                service.SetFeat(character, info, "Razortooth goblin");
            };

            info.AllowAncestoryAbility =
                [
                AbilityType.Strength,
                AbilityType.Constitution,
                AbilityType.Intelligence
            ];
        }
    }
}
