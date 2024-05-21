namespace DataBaseAccess.CoreBook.Equipment
{
    using DataBaseAccess.CoreBook.Traits;
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая оружие в базе данных.
    /// </summary>
    public class DBWeapon : DBItem
    {
        /// <summary>
        /// Кость урона оружия.
        /// </summary>
        [Required]
        public List<string> DamageDices;

        /// <summary>
        /// Типы урона оружия.
        /// </summary>
        [Required]
        public List<DamageType> DamageTypes;

        /// <summary>
        /// Тип оружия.
        /// </summary>
        [Required]
        public WeaponType Type { get; set; }

        /// <summary>
        /// Группа оружия.
        /// </summary>
        [Required]
        public WeaponGroup Group { get; set; }

        /// <summary>
        /// Признаки оружия.
        /// </summary>
        public List<WeaponTraits> Traits { get; set; }
    }
}
