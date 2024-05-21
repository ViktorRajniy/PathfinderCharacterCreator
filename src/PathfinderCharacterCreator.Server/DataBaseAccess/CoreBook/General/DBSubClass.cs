namespace DataBaseAccess.CoreBook.General
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая подкласс в базе данных.
    /// </summary>
    [Table("SubClasses")]
    public class DBSubClass
    {
        /// <summary>
        /// Ключ перечисление название подкласса.
        /// </summary>
        [Key]
        [Required]
        public SubClassType ID { get; set; }

        /// <summary>
        /// Название подкласса на русском языке.
        /// </summary>
        [Required]
        public string Name { get; set; } = "???";

        /// <summary>
        /// Описание подкласса.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";

        /// <summary>
        /// ID класса, к которому относится подкласс.
        /// </summary>
        [Required]
        public ClassType ClassID { get; set; }

        /// <summary>
        /// Класс, к которому относится подкласс.
        /// </summary>
        [ForeignKey("ClassID")]
        public DBClass Class { get; set; }
    }
}
