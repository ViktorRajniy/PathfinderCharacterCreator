namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;

    /// <summary>
    /// Интерфейс стратегии предыстории.
    /// </summary>
    public interface IBackgroundStrategy
    {
        /// <summary>
        /// Метод задаёт значения предыстории в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetBackgroundInfo(DBCharacter character);
    }
}
