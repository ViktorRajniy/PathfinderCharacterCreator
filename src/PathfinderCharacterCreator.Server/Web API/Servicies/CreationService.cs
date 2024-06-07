namespace Web_API.Servicies
{
    using DataBaseAccess;
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;
    using Microsoft.EntityFrameworkCore;
    using Model.Creation;
    using Web_API.Entities.DTO;
    using Web_API.Entities.DTO.ToView;

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
        /// Создаваемый персонаж.
        /// </summary>
        private DBCharacter _character;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="db">Объект контекста базы данных.</param>
        public CreationService(ApplicationContext db)
        {
            _db = db;
            _factory = new CharacterFactory();
            _character = new DBCharacter();
        }

        /// <summary>
        /// Загружает в класс персонажа из базы данных для изменений..
        /// </summary>
        /// <param name="id">ID искомого персонажа.</param>
        public void GetCharacter(int characterID)
        {
            var character = _db.Characters
                                        .Include(c => c.General)
                                        .Include(c => c.Stats)
                                        .Include(c => c.CreationInfo)
                                        .ToList()
                                        .Find(c => c.ID == characterID);
            if (character != null)
            {
                _character = character;
            }
        }

        /// <summary>
        /// Инициализирует пустого персонажа в базе данных.
        /// </summary>
        /// <returns>ID нового персонажа.</returns>
        public int InitialiseCharacter()
        {
            var general = InitializeDBGeneralInfo();
            var stats = InitializeDBStats();
            var creationInfo = InitializeDBCreationInfo();
            int characterID = InitializeDBCharacter(general, stats, creationInfo);

            return characterID;
        }

        /// <summary>
        /// Передающий фабрике информацию о персонаже, для установки
        /// общих параметров персонажа.
        /// </summary>
        /// <param name="infoView">Общая информация о персонаже.</param>
        public void SetGeneralParameters(GeneralInfoView infoView)
        {
            var get = new EnumGetter();
            var info = new DBGeneralInfo();

            GetCharacter(infoView.id);

            info.ClassName = get.Class(infoView.ClassName);
            info.SubClass = get.SubClass(info.ClassName, infoView.SubClass);
            info.Ancestry = get.Ancestory(infoView.Ancestry);
            info.Haritage = get.Haritage(info.Ancestry, infoView.Haritage);
            info.Background = get.Background(infoView.Background);
            info.Aligment = get.Aligment(infoView.Aligment);
            info.Deity = get.Deity(infoView.Deity);

            _factory.SetGeneralParameters(_character, info, infoView.Name);

            _db.SaveChanges();
        }

        /// <summary>
        /// Формирует и возвращает структуру описывающую текущие характеристики и возможные выборы пользователя.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Структура описывающая характеристики персонажа.</returns>
        public AbilitiesBack GetCurrentAbilities(int characterID)
        {
            var abilities = new AbilitiesBack();
            GetCharacter(characterID);
            foreach (AbilityType type in Enum.GetValues(typeof(AbilityType)))
            {
                abilities.Abilities[(int)type] = _character.Stats.Abilities[(int)type];
            }
            abilities.ClassAbilities = _character.CreationInfo.ClassOptionAbility;
            abilities.AncestoryAbilities = _character.CreationInfo.AncestoryAbility;
            abilities.BackgroundAbilities = _character.CreationInfo.BackgroundAbility;
            return abilities;
        }

        /// <summary>
        /// Передающий фабрике конечные характеристики персонажа.
        /// </summary>
        /// <param name="abilitiesView"></param>
        public void SetAbilities(AbilitiesView abilitiesView)
        {
            GetCharacter(abilitiesView.Id);

            var abilities = new Dictionary<AbilityType, int>();
            foreach (AbilityType ability in Enum.GetValues(typeof(AbilityType)))
            {
                abilities[ability] = abilitiesView.Abilities[(int)ability];
            }
            _factory.SetAbilities(_character, abilities);

            _db.SaveChanges();
        }

        /// <summary>
        /// Формирует и возвращает структуру описывающую список из которого нужно выбрать навыки и количество навыков.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Структура описывающая список возможных навыков персонажа.</returns>
        public SkillsBack GetCurrentSkills(int characterID)
        {
            var skills = new SkillsBack();
            GetCharacter(characterID);
            int currentSkillCount = _factory.GetCurrentSkillCount(_character);
            int skillCount = _factory.GetSkillCount(_character);
            skills.SkillCount = skillCount - currentSkillCount;

            foreach (SkillType type in Enum.GetValues(typeof(SkillType)))
            {
                if (_character.Stats.Skills[(int)type] == ProficientyType.Untrained)
                {
                    skills.AllowedSkillsList.Add(type);
                }
            }
            return skills;
        }

        /// <summary>
        /// Устанавливает значение навыков персонажа.
        /// </summary>
        /// <param name="skillsView">Список умений персонажа.</param>
        public void SetSkills(SkillsView skillsView)
        {
            GetCharacter(skillsView.Id);

            var skills = new Dictionary<SkillType, ProficientyType>();
            foreach (SkillType skill in Enum.GetValues(typeof(SkillType)))
            {
                skills[skill] = (ProficientyType)skillsView.Skills[(int)skill];
            }
            _factory.SetSkills(_character, skills);

            _db.SaveChanges();
        }

        /// <summary>
        /// Возвращает структуру, со списком доступных персонажу для выбора черт и их количество.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Структура со списком черт.</returns>
        public FeatsBack GetAllowedFeats(int characterID)
        {
            var feats = new FeatsBack();
            var featManager = new FeatManager();
            GetCharacter(characterID);

            feats.ClassFeatCount = _character.CreationInfo.ClassFeatCount;
            feats.AncestryFeatCount = _character.CreationInfo.AncestoryFeatCount;
            feats.GeneralFeatCount = _character.CreationInfo.GeneralFeatCount;
            feats.SkillFeatCount = _character.CreationInfo.SkillFeatCount;

            var featList = new List<FeatBase>() { };
            featList = featManager.GetAllowedFeats(_character);
            foreach (FeatBase feat in featList)
            {
                feats.AllowedFeats.Add(_db.Feats.FirstOrDefault(f => f.Name == feat.Name));
            }

            return feats;
        }

        /// <summary>
        /// Возвращает массив, в котором хранится текущее количество черт персонажа.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Массив с количеством черт.</returns>
        public List<int> GetCurrentFeatsCount(int characterID)
        {
            GetCharacter(characterID);
            return _factory.GetCurrentFeatsCount(_character);
        }

        /// <summary>
        /// Возвращает массив, в котором хранится количество черт, которыми должен владеть персонаж.
        /// </summary>
        /// <param name="characterID">ID персонажа.</param>
        /// <returns>Массив с количеством черт.</returns>
        public List<int> GetFeatsCount(int characterID)
        {
            GetCharacter(characterID);
            return _factory.GetFeatCount(_character);
        }

        /// <summary>
        /// Устанавливает персонажу черты.
        /// </summary>
        /// <param name="featsView">Список черт.</param>
        public void SetFeats(FeatsView featsView)
        {
            GetCharacter(featsView.Id);
            foreach (string feat in featsView.Feats)
            {
                _factory.SetFeat(_character, feat);
            }
            _db.SaveChanges();
        }

        public void DeleteCharacter(int id)
        {
            _db.Characters.Remove(_db.Characters.Find(id));
            _db.SaveChanges();
        }

        private int InitializeDBCharacter(DBGeneralInfo general, DBStats stats, DBCreationInfo info)
        {
            var character = new DBCharacter()
            {
                UserId = 1,
                Name = "Test Character",
                Level = 1,
                General = general,
                Stats = stats,
                CreationInfo = info,
                Wallet = 0,
                FeatNames = new List<string>() { },
                ActionNames = new List<string>() { },
                ItemNames = new List<string>() { },
            };

            _db.Characters.Add(character);
            _db.SaveChanges();

            return _db.Characters.OrderBy(c => c.ID).Last().ID;
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

        private DBCreationInfo InitializeDBCreationInfo()
        {
            var creationInfo = new DBCreationInfo
            {
                AncestoryFeatCount = 1,
                ClassFeatCount = 1,
                SkillFeatCount = 1,
                GeneralFeatCount = 0,
                AncestoryAbility = new List<AbilityType>() { },
                BackgroundAbility = new List<AbilityType>() { },
                ClassOptionAbility = new List<AbilityType>() { },
                ClassSkillsCount = 0,
            };

            _db.CreationInfos.Add(creationInfo);

            return creationInfo;
        }
    }
}
