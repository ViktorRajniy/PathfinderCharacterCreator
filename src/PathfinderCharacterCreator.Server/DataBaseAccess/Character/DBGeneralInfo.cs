namespace DataBaseAccess.Character
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая общую информацию о персонаже в базе данных.
    /// </summary>
    [Table("CharacterGenetalInfos")]
    public class DBGeneralInfo
    {
        /// <summary>
        /// ID объекта.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// ID персонажа, которому пренадлежит информация.
        /// </summary>
        public int CharacterID { get; set; }

        /// <summary>
        /// Навигационное свойство.
        /// </summary>
        [ForeignKey(nameof(CharacterID))]
        public DBCharacter? Character { get; set; }

        /// <summary>
        /// Имя персонажа.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Уровень персонажа.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Мировоззрение персонажа.
        /// </summary>
        [Required]
        public AligmentType Aligment { get; set; }

        /// <summary>
        /// Родословная персонажа.
        /// </summary>
        [Required]
        public AncestryType Ancestry { get; set; }

        /// <summary>
        /// Наследие персонажа.
        /// </summary>
        [Required]
        public HaritageType Haritage { get; set; }

        /// <summary>
        /// Предыстория персонажа.
        /// </summary>
        [Required]
        public BackgroundType Background { get; set; }

        /// <summary>
        /// Класс персонажа.
        /// </summary>
        [Required]
        public ClassType ClassName { get; set; }

        /// <summary>
        /// Подкласс персонажа.
        /// </summary>
        [Required]
        public SubClassType SubClass { get; set; }

        /// <summary>
        /// Вера персонажа.
        /// </summary>
        [Required]
        public DeityType Deity { get; set; }

        /// <summary>
        /// Размер персонажа.
        /// </summary>
        [Required]
        public SizeType Size { get; set; }
    }
}
