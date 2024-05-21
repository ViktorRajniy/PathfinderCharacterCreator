using DataBaseAccess;
using DataBaseAccess.CoreBook.Equipment;

namespace Model
{
    public class DataBaseAccessService
    {
        private ApplicationContext _db;

        public DataBaseAccessService(ApplicationContext db)
        {
            _db = db;
        }

        public List<DBItem> GetItems()
        {
            return _db.Items.ToList();
        }

        public List<DBWeapon> GetWeapon()
        {
            return _db.Weapons.ToList();
        }
    }
}
