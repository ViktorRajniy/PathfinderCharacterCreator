using DataBaseAccess;
using DataBaseAccess.Character;
using Microsoft.EntityFrameworkCore;
using Web_API.Entities.User;

namespace Web_API.Servicies
{
    public class UserService
    {
        private ApplicationContext _db;

        public UserService(ApplicationContext db)
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

        public DBUser GetUser(int id)
        {
            return _db.Users.Include(u => u.CharacterList)
                            .ToList()
                            .Find(u => u.ID == id);
        }

        public List<DBUser> GetUsersList()
        {
            return _db.Users.Include(u => u.CharacterList)
                            .ToList();
        }

        public void NewUser(DBUser user)
        {
            _db.Users.Add(user);
        }
    }
}
