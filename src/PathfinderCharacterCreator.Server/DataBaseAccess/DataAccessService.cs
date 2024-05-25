namespace DataBaseAccess
{
    using DataBaseAccess.Character;
    using Microsoft.EntityFrameworkCore;

    public class DataAccessService
    {
        private ApplicationContext _db;

        public DataAccessService(ApplicationContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Возвращает персонажа из базы данных по ID.
        /// </summary>
        /// <param name="id">ID искомого персонажа.</param>
        /// <returns>Искомый персонаж.</returns>
        public DBCharacter GetCharacter(int id)
        {
            return _db.Characters.Include(c => c.General)
                                 .Include(c => c.Stats)
                                 .ToList()
                                 .Find(c => c.ID == id);
        }

        /// <summary>
        /// Возвращает список всех персонажей в базе данных.
        /// </summary>
        /// <returns>Список персонажей.</returns>
        public List<DBCharacter> GetDBCharactersList()
        {
            return _db.Characters.Include(c => c.General)
                                 .Include(c => c.Stats)
                                 .ToList();
        }

        public List<DBUser> GetUsersList()
        {
            return _db.Users.Include(u=>u.CharacterList)
                            .ToList ();
        }
    }
}
