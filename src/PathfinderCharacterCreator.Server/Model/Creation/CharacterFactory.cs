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

            character.General.Haritage = info.Haritage;
            character.General.SubClass = info.SubClass;

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
        /// Возвращает количество пунктов навыков, которые сейчас вложены в персонажа.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <returns>Количество взятых пунктов навыков.</returns>
        public int GetCurrentSkillCount(DBCharacter character)
        {
            int count = 0;
            foreach (SkillType type in Enum.GetValues(typeof(SkillType)))
            {
                if (character.Stats.Skills[(int)type] == ProficientyType.Trained)
                {
                    count++;
                }
                else
                if (character.Stats.Skills[(int)type] == ProficientyType.Expert)
                {
                    count += 2;
                }
                else
                if (character.Stats.Skills[(int)type] == ProficientyType.Master)
                {
                    count += 3;
                }
                else
                if (character.Stats.Skills[(int)type] == ProficientyType.Legend)
                {
                    count += 4;
                }
            }
            return count;
        }

        /// <summary>
        /// Возвращает количество пунктов навыков, которые должны быть взять персонажу.
        /// </summary>
        /// <param name="character">Объект персонажа.</param>
        /// <returns>Количество пунктов навыков.</returns>
        public int GetSkillCount(DBCharacter character)
        {
            int count = 2;
            count += character.CreationInfo.SkillsCount;
            count += (character.Stats.Abilities[(int)AbilityType.Intelligence] - 10) / 2;
            return count;
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
        /// <param name="featName">Черта.</param>
        /// <param name="character">Объект персонажа.</param>
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

        public List<int> GetFeatCount(DBCharacter character)
        {
            var counts = new List<int>() { };
            counts.Add(0);
            counts.Add(character.CreationInfo.GeneralFeatCount);
            counts.Add(character.CreationInfo.AncestoryFeatCount);
            counts.Add(character.CreationInfo.SkillFeatCount);
            counts.Add(character.CreationInfo.ClassFeatCount);

            return counts;
        }

        public List<int> GetCurrentFeatsCount(DBCharacter character)
        {
            List<int> counts = [0, 0, 0, 0, 0];
            foreach (FeatType type in Enum.GetValues(typeof(FeatType)))
            {
                counts[(int)type] = GetFeatCountByType(character, type);
            }
            return counts;
        }

        private int GetFeatCountByType(DBCharacter character, FeatType type)
        {
            int count = 0;
            var featManager = new FeatManager();
            foreach (var feat in character.FeatNames)
            {
                var findedFeat = featManager.FindFeat(feat);
                if (findedFeat.Type == type)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
