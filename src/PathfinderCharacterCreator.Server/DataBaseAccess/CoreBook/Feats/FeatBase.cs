namespace DataBaseAccess.CoreBook.Feats
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Черта и логика работы с ней.
    /// </summary>
    public class FeatBase
    {
        /// <summary>
        /// Название черты персонажа.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип черты.
        /// </summary>
        public FeatType Type { get; set; }

        /// <summary>
        /// Требуемый уровень для получения черты.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Делегат, возвращающий булевое значение, может ли персонаж 
        /// иметь эту черту.
        /// </summary>
        /// <param name="info">Информация о персонаже.</param>
        /// <returns>True - если персонаж может владить чертой.
        /// False - если не может.</returns>
        public delegate bool CanBeAssignDeleagte(DBCharacter info);

        /// <summary>
        /// Делегат, содержащий логику черты.
        /// </summary>
        /// <param name="characterInfo">Информация о персонаже для изменения.</param>
        public delegate void AssignDelegate(DBCharacter characterInfo);

        /// <summary>
        /// Переменная делегата CanBeAssignDeleagte
        /// </summary>
        [JsonIgnore]
        public CanBeAssignDeleagte CanAssign { get; set; }

        /// <summary>
        /// Переменная делегата AssignDelegate.
        /// </summary>
        [JsonIgnore]
        public AssignDelegate Assign { get; set; }
    }
}
