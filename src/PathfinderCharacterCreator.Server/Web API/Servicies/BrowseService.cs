namespace Web_API.Servicies
{
    using DataBaseAccess;
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Equipment;
    using DataBaseAccess.CoreBook.Feats;
    using DataBaseAccess.CoreBook.Types;
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Web_API.Entities.DTO.ToView.Browse;

    public class BrowseService
    {

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
        public BrowseService(ApplicationContext db)
        {
            _db = db;
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

        public BrowseGeneralBack GetGeneralInfo(int characterID)
        {
            var info = new BrowseGeneralBack();
            var get = new EnumGetter();
            GetCharacter(characterID);

            info.Name = _character.Name;
            info.ClassName = get.RusClassName(_character.General.ClassName);
            info.SubClassName = get.RusSubClassName(_character.General.SubClass);
            info.BackgroundName = get.RusBackgroundName(_character.General.Background);
            info.AncestryName = get.RusAncestoryName(_character.General.Ancestry);
            info.HaritageName = get.RusHeritageName(_character.General.Haritage);
            info.DeityName = get.RusDeityName(_character.General.Deity);
            info.Size = get.RusSizeName(_character.General.Size);
            info.Aligment = get.RusAligmentName(_character.General.Aligment);

            return info;
        }

        public List<DBFeat> GetFeats(int characterID)
        {
            var featList = new List<DBFeat>();
            GetCharacter(characterID);
            foreach (var feat in _character.FeatNames)
            {
                var findedFeat = _db.Feats.Find(feat);
                if (findedFeat != null)
                {
                    featList.Add(findedFeat);
                }
            }
            return featList;
        }

        public List<DBItem> GetEquipment(int characterID)
        {
            var itemList = new List<DBItem>();
            GetCharacter(characterID);
            foreach (var item in _character.ItemNames)
            {
                var findedItem = _db.Items.Find(item);
                if (findedItem != null)
                {
                    itemList.Add(findedItem);
                }
            }
            return itemList;
        }

        public List<BrowseSkillBack> GetSkills(int characterID)
        {
            GetCharacter(characterID);

            var list = new List<BrowseSkillBack>();
            var get = new EnumGetter();

            var mod = new ModifierCalculator();
            var modList = mod.SkillModifiers(_character);

            foreach (SkillType skill in Enum.GetValues(typeof(SkillType)))
            {
                list.Add(new BrowseSkillBack
                {
                    Name = get.RusSkillName(skill),
                    Modifier = modList[skill],
                    Description = "",
                });
            }

            return list;
        }
    }
}
