namespace DataBaseAccess.CoreBook.General
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая предысторию в базе данных.
    /// </summary>
    [Table("Backgrounds")]
    public class DBBackground
    {
        /// <summary>
        /// Ключ перечисление название предыстории.
        /// </summary>
        [Key]
        [Required]
        public BackgroundType ID { get; set; }

        /// <summary>
        /// Название предыстории на русском языке.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание предыстории.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Навык изучаемый предысторией.
        /// </summary>
        [Required]
        public SkillType SkillTrained { get; set; }

        /// <summary>
        /// Черта навыка полученная от предыстории.
        /// </summary>
        [Required]
        public string FeatTrained { get; set; }
    }
}
