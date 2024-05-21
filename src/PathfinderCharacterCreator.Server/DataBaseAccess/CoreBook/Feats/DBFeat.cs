namespace DataBaseAccess.CoreBook.Feats
{
    using DataBaseAccess.CoreBook.Traits;
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая черту в базе данных.
    /// </summary>
    [Table("Feats")]
    public class DBFeat
    {
        /// <summary>
        /// Название черты на английском языке.
        /// </summary>
        [Key]
        [Required]
        public string Name { get; set; } = "???";

        /// <summary>
        /// Название черты на русском языке.
        /// </summary>
        [Required]
        public string RussianName { get; set; } = "???";

        /// <summary>
        /// Описание черты.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";

        /// <summary>
        /// Уровень черты.
        /// </summary>
        [Required]
        public int Level { get; set; }

        /// <summary>
        /// Тип черты.
        /// </summary>
        [Required]
        public FeatType Type { get; set; }

        /// <summary>
        /// Трейты черты.
        /// </summary>
        public List<FeatTraits>? Traits { get; set; }
    }
}
