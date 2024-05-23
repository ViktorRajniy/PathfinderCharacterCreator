using DataBaseAccess;
using DataBaseAccess.Character;
using DataBaseAccess.CoreBook.Types;
using Model.Creation;

namespace Web_API.Servicies
{
    public class CreationService
    {
        /// <summary>
        /// Фабрака для создания персонажа.
        /// </summary>
        private CharacterFactory _factory;

        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private ApplicationContext _db;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="db">Объект контекста базы данных.</param>
        public CreationService(ApplicationContext db)
        {
            _db = db;
            _factory = new CharacterFactory();
        }

        /// <summary>
        /// Инициализирует пустого персонажа в базе данных.
        /// </summary>
        /// <returns>ID нового персонажа.</returns>
        public int InitialiseCharacter()
        {
            var general = InitializeDBGeneralInfo();
            var stats = InitializeDBStats();
            int characterID = InitializeDBCharacter(general, stats);
            _db.SaveChanges();

            return _db.Characters.OrderBy(c => c.ID).Last().ID;
        }

        /// <summary>
        /// Возвращает персонажа из базы данных по ID.
        /// </summary>
        /// <param name="id">ID искомого персонажа.</param>
        /// <returns>Искомый персонаж.</returns>
        public DBCharacter GetCharacter(int id)
        {
            return GetDBCharactersList().Find(c => c.ID == id);
        }

        /// <summary>
        /// Возвращает список всех персонажей в базе данных.
        /// </summary>
        /// <returns>Список персонажей.</returns>
        public List<DBCharacter> GetDBCharactersList()
        {
            var charactersList = from character in _db.Characters
                                 join stats in _db.Stats on character.ID equals stats.CharacterID
                                 join general in _db.GeneralInfos on character.ID equals general.CharacterID
                                 select new DBCharacter
                                 {
                                     ID = character.ID,
                                     Name = character.Name,
                                     ActionNames = character.ActionNames,
                                     FeatNames = character.FeatNames,
                                     ItemNames = character.ItemNames,
                                     General = general,
                                     Level = character.Level,
                                     Stats = stats,
                                     Wallet = character.Wallet,
                                 };
            return charactersList.ToList();
        }

        private int InitializeDBCharacter(DBGeneralInfo general, DBStats stats)
        {
            var character = new DBCharacter()
            {
                UserId = 1,
                Name = "Test Character",
                Level = 1,
                General = general,
                Stats = stats,
                Wallet = 0,
                FeatNames = new List<string>() { },
                ActionNames = new List<string>() { },
                ItemNames = new List<string>() { },
            };

            _db.Characters.Add(character);

            return character.ID;
        }

        private DBStats InitializeDBStats()
        {
            var stats = new DBStats
            {
                CharacterID = 1,
                CurrentHealthPoints = 0,
                MaxHealthPoints = 0,
                Speed = 0,
                Abilities = [10, 10, 10, 10, 10, 10],
                SavingThrows = [0, 0, 0],
                Skills = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                WeaponProficienty = [0, 0, 0, 0],
                ArmorProficienty = [0, 0, 0, 0],
            };

            _db.Stats.Add(stats);

            return stats;
        }

        private DBGeneralInfo InitializeDBGeneralInfo()
        {
            var general = new DBGeneralInfo
            {
                Ancestry = AncestryType.None,
                Haritage = HaritageType.None,
                Background = BackgroundType.None,
                ClassName = ClassType.None,
                SubClass = SubClassType.None,
                Aligment = AligmentType.None,
                Size = SizeType.Medium,
                Deity = DeityType.Atheism,
            };

            _db.GeneralInfos.Add(general);

            return general;
        }
    }
}
