namespace DataBaseAccess.CoreBook.Skills
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Навык.
    /// </summary>
    [Table("Skills")]
    public class DBSkill
    {
        /// <summary>
        /// Название элемента.
        /// </summary>
        [Key]
        [Required]
        public SkillType ID { get; set; }

        /// <summary>
        /// Название навыка на русском языке.
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
