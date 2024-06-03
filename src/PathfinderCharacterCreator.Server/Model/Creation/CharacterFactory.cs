namespace Model.Creation
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Feats;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс отвечающий за создание персонажа.
    /// </summary>
    public class CharacterFactory
    {

        /// <summary>
        /// Промежуточная информация для создания персонажа.
        /// </summary>
        public DBCreationInfo CreationInfo { get; private set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public CharacterFactory()
        {
            CreationInfo = new DBCreationInfo();
        }

        /// <summary>
        /// Присваивает параметры, зависящие от расы, класса и предыстории 
        /// в поля персонажа.
        /// </summary>
        /// <param name="info">Общие параметры персонажа.</param>
        public void SetGeneralParameters(DBCharacter character, DBGeneralInfo info, string Name)
        {
            var strategies = new Strategies.Strategies();

            character.Name = Name;
            character.General.Deity = info.Deity;
            character.General.Aligment = info.Aligment;

            character.Wallet = 1500;

            strategies.Class[info.ClassName].SetClassInfo(character);
            strategies.Ancestory[info.Ancestry].SetAncestriesInfo(character);
            strategies.Background[info.Background].SetBackgroundInfo(character);
        }

        /// <summary>
        /// Присваивает характеристики персонажу.
        /// </summary>
        /// <param name="abilities">Итоговое значение характеристик.</param>
        public void SetAbilities(DBCharacter character, Dictionary<AbilityType, int> abilities)
        {
            foreach (AbilityType ability in Enum.GetValues(typeof(AbilityType)))
            {
                character.Stats.Abilities[(int)ability] = abilities[ability];
            }

            // TODO
            // CreationInfo.SkillsCount +=
            //    (character.Info.Stats.Abilities[(int)AbilityType.Intelligence] - 10)/2;
        }

        /// <summary>
        /// Устанавливает значения навыков персонажа.
        /// </summary>
        /// <param name="skills">Структура данных навыков персонажа.</param>
        public void SetSkills(DBCharacter character, Dictionary<SkillType, ProficientyType> skills)
        {
            foreach (SkillType skill in Enum.GetValues(typeof(SkillType)))
            {
                character.Stats.Skills[(int)skill] = skills[skill];
            }
        }

        /// <summary>
        /// Устанавливает персонажу связь с чертой.
        /// </summary>
        /// <param name="feat">Черта.</param>
        public void SetFeat(DBCharacter character, string featName)
        {
            var featManager = new FeatManager();
            var feat = featManager.FindFeat(featName);
            if (feat != null && feat.CanAssign(character))
            {
                feat.Assign(character);
                character.FeatNames.Add(feat.Name);
            }
        }
    }
}
