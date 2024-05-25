namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Человека создаваемому персонажу.
    /// </summary>
    public class HumanStrategy : IAncestriesStrategy
    {
        /// <summary>
        /// Метод задаёт значения родословной человека в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetAncestriesInfo(DBCharacter character, HaritageType haritage, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.General.Ancestry = AncestryType.Human;

            character.General.Size = SizeType.Medium;

            service.SetHealthPoints(character, 8);

            character.Stats.Speed = 25;

            info.SecondAncestoryAbility = true;
            info.AllowAncestoryAbility = null;

            if (haritage == HaritageType.SkilledHeritage)
            {
                service.SetFeat(character, info, "Skilled heritage");
            }

            if (haritage == HaritageType.VersatileHeritage)
            {
                service.SetFeat(character, info, "Versatile heritage");
            }
        }
    }
}
