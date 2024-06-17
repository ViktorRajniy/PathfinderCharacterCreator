namespace DataBaseAccess.CoreBook.Actions
{
    using DataBaseAccess.CoreBook.Traits;
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Действие.
    /// </summary>
    [Table("Actions")]
    public class DBAction
    {
        /// <summary>
        /// Название элемента.
        /// </summary>
        [Key]
        [Required]
        public string Name { get; set; } = "???";

        /// <summary>
        /// Название действия на русском языке.
        /// </summary>
        [Required]
        public string RussianName { get; set; } = "???";

        /// <summary>
        /// Описание элемента.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";

        /// <summary>
        /// Описание триггера действия.
        /// </summary>
        public string? Trigger { get; set; }

        /// <summary>
        /// Описание требования действия.
        /// </summary>
        public string? Requirement { get; set; }

        /// <summary>
        /// Тип действия.
        /// </summary>
        [Required]
        public ActionType Type { get; set; }

        /// <summary>
        /// Трейты действия.
        /// </summary>
        public List<ActionTraits>? Traits { get; set; }
    }
}
