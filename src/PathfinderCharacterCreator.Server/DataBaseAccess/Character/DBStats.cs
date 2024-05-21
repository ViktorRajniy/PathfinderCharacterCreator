namespace DataBaseAccess.Character
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Параметры персонажа.
    /// </summary>
    [Table("CharacterStats")]
    public class DBStats
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
        /// Текущее количество пунктов здоровья.
        /// </summary>
        public int CurrentHealthPoints { get; set; }

        /// <summary>
        /// Максимальное количество пунктов здоровья.
        /// </summary>
        public int MaxHealthPoints { get; set; }

        /// <summary>
        /// Скорость персонажа.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Характеристики персонажа.
        /// </summary>
        public int[] Abilities { get; set; } = new int[6];

        /// <summary>
        /// Спасброски персонажа.
        /// </summary>
        public ProficientyType[] SavingThrows { get; set; } = new ProficientyType[3];

        /// <summary>
        /// Навыки персонажа.
        /// </summary>
        public ProficientyType[] Skills { get; set; } = new ProficientyType[18];

        /// <summary>
        /// Умения персонажа в вооружении.
        /// </summary>
        public ProficientyType[] WeaponProficienty { get; set; } = new ProficientyType[4];

        /// <summary>
        /// Умения персонажа в обращении с бронёй.
        /// </summary>
        public ProficientyType[] ArmorProficienty { get; set; } = new ProficientyType[4];
    }
}
