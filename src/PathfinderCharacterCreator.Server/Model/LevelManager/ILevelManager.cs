namespace Model.LevelManager
{
    using DataBaseAccess.Character;

    /// <summary>
    /// Интерфейс менеджера уровней.
    /// </summary>
    public interface ILevelManager
    {
        /// <summary> 
        /// Метод повышающий уровень персонажа.
        /// </summary>
        /// <param name="character">Структура значений персонажа.</param>
        public void LevelUp(DBCharacter character);
    }
}
