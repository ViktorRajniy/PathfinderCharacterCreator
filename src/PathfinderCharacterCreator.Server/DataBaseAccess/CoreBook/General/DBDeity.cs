namespace DataBaseAccess.CoreBook.General
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая божество в базе данных.
    /// </summary>
    [Table("Daities")]
    public class DBDeity
    {
        /// <summary>
        /// Ключ перечисление название божества.
        /// </summary>
        [Key]
        [Required]
        public DeityType ID { get; set; }

        /// <summary>
        /// Название божества на русском языке.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание божества.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
