namespace Model.LevelManager
{
    using DataBaseAccess.Character;

    /// <summary>
    /// Менеджер уровней Волшебника.
    /// </summary>
    public class WizzardLevelManager : ILevelManager
    {
        /// <summary>
        /// Метод повышающий уровень Волшебника.
        /// </summary>
        /// <param name="character">Структура значений персонажа.</param>
        public void LevelUp(DBCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
