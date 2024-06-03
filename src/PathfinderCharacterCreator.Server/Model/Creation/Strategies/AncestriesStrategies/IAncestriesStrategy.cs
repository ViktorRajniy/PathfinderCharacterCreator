namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;

    /// <summary>
    /// Интерфейс стратегии родословной.
    /// </summary>
    public interface IAncestriesStrategy
    {
        /// <summary>
        /// Метод задаёт значения родословной в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetAncestriesInfo(DBCharacter character);
    }
}
