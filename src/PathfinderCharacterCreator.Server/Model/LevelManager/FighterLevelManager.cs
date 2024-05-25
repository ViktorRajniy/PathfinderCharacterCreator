namespace Model.LevelManager
{
    using DataBaseAccess.Character;

    /// <summary>
    /// Менеджер уровней Воина.
    /// </summary>
    public class FighterLevelManager : ILevelManager
    {
        /// <summary>
        /// Метод повышающий уровень Воина.
        /// </summary>
        /// <param name="character">Структура значений персонажа.</param>
        public void LevelUp(DBCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
