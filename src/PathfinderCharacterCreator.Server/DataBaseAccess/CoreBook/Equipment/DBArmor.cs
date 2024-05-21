namespace DataBaseAccess.CoreBook.Equipment
{
    using DataBaseAccess.CoreBook.Traits;
    using DataBaseAccess.CoreBook.Types;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая броню в базе данных.
    /// </summary>
    public class DBArmor : DBItem
    {
        /// <summary>
        /// Бонус доспеха к КБ.
        /// </summary>
        [Required]
        public int ArmorBonus { get; set; }

        /// <summary>
        /// Максимальная ловкость в доспехе.
        /// </summary>
        [Required]
        public int DexterityCapacity { get; set; }

        /// <summary>
        /// Штраф доспеха к навыкам.
        /// </summary>
        [Required]
        public int CheckPenalty { get; set; }

        /// <summary>
        /// Штраф доспеха к скорости.
        /// </summary>
        [Required]
        public int SpeedPenalty { get; set; }

        /// <summary>
        /// Требование доспеха к силе.
        /// </summary>
        [Required]
        public int Strength { get; set; }

        /// <summary>
        /// Тип доспеха.
        /// </summary>
        [Required]
        public ArmorType Type { get; set; }

        /// <summary>
        /// Группа доспеха.
        /// </summary>
        [Required]
        public ArmorGroup Group { get; set; }

        /// <summary>
        /// Признаки доспеха.
        /// </summary>
        public List<ArmorTraits>? Traits { get; set; }
    }
}
