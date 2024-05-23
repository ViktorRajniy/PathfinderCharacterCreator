namespace DataBaseAccess.Character
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Структура, описывающая персонажа в базе данных.
    /// </summary>
    [Table("Characters")]
    public class DBCharacter
    {
        /// <summary>
        /// ID персонажа.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// ID пользователя, которому пренадлежит персонаж.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public DBUser? User { get; set; }

        /// <summary>
        /// Имя персонажа.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Уровень персонажа.
        /// </summary>
        [Required]
        public int Level { get; set; }

        /// <summary>
        /// Общая информация о персонаже.
        /// </summary>
        [Required]
        public DBGeneralInfo General { get; set; }

        /// <summary>
        /// Характеристики персонажа.
        /// </summary>
        [Required]
        public DBStats Stats { get; set; }

        /// <summary>
        /// Кошелёк персонажа.
        /// </summary>
        [Required]
        public int Wallet { get; set; } = 0;

        /// <summary>
        /// Список названий черт, которыми владеет персонаж.
        /// </summary>
        public List<string>? FeatNames { get; set; }

        /// <summary>
        /// Список названий действий, которыми владеет персонаж.
        /// </summary>
        public List<string>? ActionNames { get; set; }

        /// <summary>
        /// Список названий предметов, которыми владеет персонаж.
        /// </summary>
        public List<string>? ItemNames { get; set; }
    }
}
