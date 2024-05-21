namespace DataBaseAccess.CoreBook.General
{
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая класс в базе данных.
    /// </summary>
    [Table("Classes")]
    public class DBClass
    {
        /// <summary>
        /// Ключ перечисление название класса.
        /// </summary>
        [Key]
        [Required]
        public ClassType ID { get; set; }

        /// <summary>
        /// Название класса на русском языке.
        /// </summary>
        [Required]
        public string ClassName { get; set; } = "???";

        /// <summary>
        /// Описание класса.
        /// </summary>
        [Required]
        public string Description { get; set; } = "???";

        /// <summary>
        /// Описание класса раздел Вы можете...
        /// </summary>
        [Required]
        public string YouCanDescription { get; set; } = "???";

        /// <summary>
        /// Описание класса раздел Другие возможно...
        /// </summary>
        [Required]
        public string OtherMaybeDescription { get; set; } = "???";

        /// <summary>
        /// Пункты здоровья класса.
        /// </summary>
        [Required]
        public int HealthPoints { get; set; }

        /// <summary>
        /// Умение класса в восприятии.
        /// </summary>
        [Required]
        public ProficientyType Perception { get; set; }

        /// <summary>
        /// Умение класса в спасброске стойкости.
        /// </summary>
        [Required]
        public ProficientyType Fortitude { get; set; }

        /// <summary>
        /// Умение класса в спасброске реакции.
        /// </summary>
        [Required]
        public ProficientyType Reflex { get; set; }

        /// <summary>
        /// Умение класса в спасброске воли.
        /// </summary>
        [Required]
        public ProficientyType Will { get; set; }

        /// <summary>
        /// Количество навыков от класса.
        /// </summary>
        [Required]
        public int SkillsCount { get; set; }

        /// <summary>
        /// Навык изучаемый классом.
        /// </summary>
        public SkillType? ClassSkill { get; set; }

        /// <summary>
        /// Список возможных подклассов класса.
        /// </summary>
        public List<DBSubClass>? SubClasses { get; set; }
    }
}
