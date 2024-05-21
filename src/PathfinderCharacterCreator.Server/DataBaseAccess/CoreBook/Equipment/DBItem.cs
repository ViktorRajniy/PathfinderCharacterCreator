namespace DataBaseAccess.CoreBook.Equipment
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Структура описывающая предмет в базе данных.
    /// </summary>
    [Table("Items")]
    public class DBItem
    {
        /// <summary>
        /// Название предмета.
        /// </summary>
        [Key]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Стоимость предмета.
        /// </summary>
        [Required]
        public virtual int Cost { get; set; }

        /// <summary>
        /// Масса предмета.
        /// </summary>
        [Required]
        public virtual double Weight { get; set; }
    }
}
