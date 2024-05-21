namespace DataBaseAccess.CoreBook.General
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая наследие в базе данных.
    /// </summary>
    [Table("Haritages")]
    public class DBHaritage
    {
        /// <summary>
        /// Ключ перечисление название наследия.
        /// </summary>
        [Key]
        [Required]
        public HaritageType ID { get; set; }

        /// <summary>
        /// Название наследия на русском языке.
        /// </summary>
        [Required]
        public string Name { get; set; } = "???";

        /// <summary>
        /// Описание наследия.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";

        /// <summary>
        /// ID родословной, к которой относится наследие.
        /// </summary>
        public AncestryType? AncestryID { get; set; }

        /// <summary>
        /// Родословная, к которой относится наследие.
        /// </summary>
        [ForeignKey("AncestryID")]
        public DBAncestry? Ancestry { get; set; }
    }
}
