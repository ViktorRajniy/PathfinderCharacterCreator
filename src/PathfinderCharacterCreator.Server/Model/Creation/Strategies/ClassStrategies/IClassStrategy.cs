namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;

    /// <summary>
    /// Интерфейс стратегии класса.
    /// Присваивает значения класса создаваемому персонажу.
    /// </summary>
    public interface IClassStrategy
    {
        /// <summary>
        /// Метод задаёт значения класса в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetClassInfo(Character character);
    }
}
