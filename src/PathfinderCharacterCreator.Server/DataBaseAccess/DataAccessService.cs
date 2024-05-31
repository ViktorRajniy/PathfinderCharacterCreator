namespace DataBaseAccess
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Abilities;
    using DataBaseAccess.CoreBook.Feats;
    using DataBaseAccess.CoreBook.General;
    using DataBaseAccess.CoreBook.Skills;
    using DataBaseAccess.CoreBook.Types;
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

        public List<DBCharacter> GetDBCharactersList()
        {
            var characters = _db.Characters
                                        .Include(c => c.General)
                                        .Include(c => c.Stats)
                                        .ToList();

            return characters;
        }

        /// <summary>
        /// Возвращает описания всех родословных.
        /// </summary>
        /// <returns>Список из описаний всех родословных.</returns>
        public List<DBAncestry> GetAncestries()
        {
            return _db.Ancestries.ToList();
        }

        /// <summary>
        /// Возвращает описания всех наследий для конкретной родословной.
        /// </summary>
        /// <param name="ancestryType">ID родословной.</param>
        /// <returns>Список из описаний наследий для родословной.</returns>
        public List<DBHaritage> GetHaritages(int ancestryType)
        {
            return _db.Haritages.Where(h => h.AncestryID == (AncestryType)ancestryType).ToList();
        }

        /// <summary>
        /// Возвращает описания всех классов.
        /// </summary>
        /// <returns>Список из описаний всех классов.</returns>
        public List<DBClass> GetClasses()
        {
            return _db.Class.ToList();
        }

        /// <summary>
        /// Возвращает описания всех подклассов для конкретного класса.
        /// </summary>
        /// <param name="classType">ID класса.</param>
        /// <returns>Список из описаний подклассов для класса.</returns>
        public List<DBSubClass> GetSubclasses(int classType)
        {
            return _db.Subclasses.Where(h => h.ClassID == (ClassType)classType).ToList();
        }

        /// <summary>
        /// Возвращает описания всех предысторий.
        /// </summary>
        /// <returns>Список из описаний всех предысторий.</returns>
        public List<DBBackground> GetBackgrounds()
        {
            return _db.Backgrounds.ToList();
        }

        /// <summary>
        /// Возвращает описания всех божеств.
        /// </summary>
        /// <returns>Список из описаний всех божеств.</returns>
        public List<DBDeity> GetDeities()
        {
            return _db.Deities.ToList();
        }

        /// <summary>
        /// Возвращает описания всех характеристик.
        /// </summary>
        /// <returns>Список из описаний всех характеристик.</returns>
        public List<DBAbility> GetAbilities()
        {
            return _db.Abilities.ToList();
        }

        /// <summary>
        /// Возвращает описания всех навыков.
        /// </summary>
        /// <returns>Список из описаний всех навыков.</returns>
        public List<DBSkill> GetSkills()
        {
            return _db.Skills.ToList();
        }

        /// <summary>
        /// Возвращает описания черт определённого типа.
        /// </summary>
        /// <param name="featType"></param>
        /// <returns>Список из описаний всех навыков.</returns>
        public List<DBFeat> GetFeatsByType(int featType)
        {
            return GetExistingFeatList().Where(f => f.Type == (FeatType)featType).ToList();
        }

        /// <summary>
        /// Возвращает список черт прописанных в коде и существующих в БД.
        /// </summary>
        /// <returns>Список полноценно существующих черт.</returns>
        public List<DBFeat> GetExistingFeatList()
        {
            var featManager = new FeatManager();

            return GetCommon(featManager.AllFeats.Feats, _db.Feats.ToList());
        }

        /// <summary>
        /// Выделяет общее из списка прописанных в коде черт и списка существующих в БД черт.
        /// </summary>
        /// <param name="allowedFeats">Список черт прописанных в коде.</param>
        /// <param name="databaseFeats">Список черт существующих в БД.</param>
        /// <returns>Список черт существующих в обоих списках.</returns>
        private List<DBFeat> GetCommon(List<FeatBase> allowedFeats, List<DBFeat> databaseFeats)
        {
            var result = new List<DBFeat>();
            foreach (var feat in allowedFeats)
            {
                DBFeat findedFeat = databaseFeats.Find(f => f.Name == feat.Name);
                if (findedFeat != null)
                {
                    result.Add(findedFeat);
                }
            }
            return result;
        }
    }
}
