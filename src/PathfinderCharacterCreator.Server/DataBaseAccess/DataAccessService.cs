namespace DataBaseAccess
{
    using DataBaseAccess.Character;
    using Microsoft.EntityFrameworkCore;

    public class DataAccessService
    {
        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private ApplicationContext _db;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="db">Объект контекста базы данных.</param>
        public DataAccessService(ApplicationContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Загружает в класс персонажа из базы данных для изменений..
        /// </summary>
        /// <param name="characterID">ID искомого персонажа.</param>
        public DBCharacter GetDBCharacter(int characterID)
        {
            var character = _db.Characters
                                        .Include(c => c.General)
                                        .Include(c => c.Stats)
                                        .ToList()
                                        .Find(c => c.ID == characterID);
            if (character != null)
            {
                return character;
            }

            return null;
        }

        /// <summary>
        /// Загружает в класс персонажа из базы данных для изменений..
        /// </summary>
        /// <param name="id">ID искомого персонажа.</param>
        public List<DBCharacter> GetDBCharactersList()
        {
            var characters = _db.Characters
                                        .Include(c => c.General)
                                        .Include(c => c.Stats)
                                        .ToList();

            return characters;
        }
    }
}
