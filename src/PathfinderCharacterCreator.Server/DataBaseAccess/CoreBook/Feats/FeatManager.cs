using DataBaseAccess.Character;

namespace DataBaseAccess.CoreBook.Feats
{
    /// <summary>
    /// Менеджер черт.
    /// </summary>
    public class FeatManager
    {
        /// <summary>
        /// Объект хранящий все черты.
        /// </summary>
        public AllFeats AllFeats { get; set; }

        /// <summary>
        /// Метод формирует список из всех доступных персонажу черт.
        /// </summary>
        /// <param name="info">Информация о персонаже.</param>
        /// <returns>Список доступных черт.</returns>
        public List<FeatBase> GetAllowedFeats(DBCharacter info)
        {
            List<FeatBase> allowedFeats = new List<FeatBase>();

            foreach (FeatBase feat in AllFeats.Feats)
            {
                if (feat.CanAssign(info))
                    allowedFeats.Add(feat);
            }

            return allowedFeats;
        }

        /// <summary>
        /// Находит и возвращает черту по её названию.
        /// </summary>
        /// <param name="featName">Название искомой черты.</param>
        /// <returns>Черта.</returns>
        public FeatBase FindFeat(string featName)
        {
            foreach (var feat in AllFeats.Feats)
            {
                if (feat.Name == featName)
                    return feat;
            }

            return null;
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public FeatManager()
        {
            AllFeats = AllFeats.Instance();
        }
    }
}
