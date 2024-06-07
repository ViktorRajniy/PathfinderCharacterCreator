namespace DataBaseAccess.Character
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Описывает информацию о персонаже для создания.
    /// </summary>
    [Table("CreationInfo")]
    public class DBCreationInfo
    {
        /// <summary>
        /// ID информации о персонаже.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Список доступных для повышения характеристик родословной.
        /// Может быть пустым, в случае 2 свободных характеристик.
        /// </summary>
        [Required]
        public List<AbilityType> AncestoryAbility { get; set; } = new List<AbilityType>() { };

        /// <summary>
        /// Список доступных для повышения характеристик класса.
        /// Может быть пустым, если не нужно выбирать характеристику.
        /// </summary>
        [Required]
        public List<AbilityType> ClassOptionAbility { get; set; } = new List<AbilityType>() { };

        /// <summary>
        /// Список из двух доступных для повышения характеристик предыстории.
        /// </summary>
        [Required]
        public List<AbilityType> BackgroundAbility { get; set; } = new List<AbilityType>() { };

        /// <summary>
        /// Количество навыков персонажа.
        /// </summary>
        public int SkillsCount { get; set; } = 0;

        /// <summary>
        /// Количество классовых черт.
        /// </summary>
        public int ClassFeatCount { get; set; }

        /// <summary>
        /// Количество черт наследия.
        /// </summary>
        public int AncestoryFeatCount { get; set; }

        /// <summary>
        /// Количество черт навыков.
        /// </summary>
        public int SkillFeatCount { get; set; }

        /// <summary>
        /// Количество общих черт.
        /// </summary>
        public int GeneralFeatCount { get; set; }
    }
}
