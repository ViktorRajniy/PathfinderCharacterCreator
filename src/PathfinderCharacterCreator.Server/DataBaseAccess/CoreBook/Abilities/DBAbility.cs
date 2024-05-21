namespace DataBaseAccess.CoreBook.Abilities
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Характеристика.
    /// </summary>
    [Table("Abilities")]
    public class DBAbility
    {
        /// <summary>
        /// Ключ перечисление название характеристики.
        /// </summary>
        [Key]
        [Required]
        public AbilityType ID { get; set; }

        /// <summary>
        /// Название характеристики на русском языке.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание элемента.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";
    }
}
