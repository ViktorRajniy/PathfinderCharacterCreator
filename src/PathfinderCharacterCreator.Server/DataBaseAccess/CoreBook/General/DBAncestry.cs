namespace DataBaseAccess.CoreBook.General
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая родословную в базе данных.
    /// </summary>
    [Table("Ancestries")]
    public class DBAncestry
    {
        /// <summary>
        /// Ключ перечисление название родословной.
        /// </summary>
        [Key]
        [Required]
        public AncestryType ID { get; set; }

        /// <summary>
        /// Название родословной на русском языке.
        /// </summary>
        [Required]
        public string Name { get; set; } = "???";

        /// <summary>
        /// Описание родословной.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";

        /// <summary>
        /// Описание родословной раздел Вы можете...
        /// </summary>
        [Required]
        public string YouCanDescription { get; set; } = "???";

        /// <summary>
        /// Описание родословной раздел Другие возможно...
        /// </summary>
        [Required]
        public string OtherMaybeDescription { get; set; } = "???";

        /// <summary>
        /// Физическое описание родословной.
        /// </summary>
        [Required]
        public string PhisicalDescription { get; set; } = "???";

        /// <summary>
        /// Пункты здоровья родословной.
        /// </summary>
        [Required]
        public int HealthPoints { get; set; }

        /// <summary>
        /// Скорость родословной.
        /// </summary>
        [Required]
        public int Speed { get; set; }

        /// <summary>
        /// Коллекция наследий родословной.
        /// </summary>
        [Required]
        public List<DBHaritage> Haritages { get; set; }
    }
}
