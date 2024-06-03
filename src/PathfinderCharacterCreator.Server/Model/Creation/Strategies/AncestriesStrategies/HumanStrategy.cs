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
        public void SetAncestriesInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.Ancestry = AncestryType.Human;

            character.General.Size = SizeType.Medium;

            service.SetHealthPoints(character, 8);

            character.Stats.Speed = 25;

            if (character.General.Haritage == HaritageType.SkilledHeritage)
            {
                service.SetFeat(character, "Skilled heritage");
            }

            if (character.General.Haritage == HaritageType.VersatileHeritage)
            {
                service.SetFeat(character, "Versatile heritage");
            }
        }
    }
}
