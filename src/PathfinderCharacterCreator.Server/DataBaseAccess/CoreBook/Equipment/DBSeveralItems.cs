namespace DataBaseAccess.CoreBook.Equipment
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Структура описывающая несколько предметов в базе данных.
    /// </summary>
    public class DBSeveralItems : DBItem
    {
        /// <summary>
        /// Стоимость пердмета.
        /// </summary>
        [Required]
        public override int Cost
        {
            get
            {
                return Count / SeveralCount * SeveralElementCost;
            }
        }

        /// <summary>
        /// Масса предмета.
        /// </summary>
        [Required]
        public override double Weight
        {
            get
            {
                return Count / SeveralCount * SeveralElementWeight;
            }
        }

        /// <summary>
        /// Количество предметов.
        /// </summary>
        [Required]
        public int Count { get; set; }

        /// <summary>
        /// Определённое количество предметов.
        /// </summary>
        [Required]
        public int SeveralCount { get; set; }

        /// <summary>
        /// Вес определённого количества премедтов.
        /// </summary>
        [Required]
        public double SeveralElementWeight { get; set; }

        /// <summary>
        /// Цена определённого количества премедтов.
        /// </summary>
        [Required]
        public int SeveralElementCost { get; set; }
    }
}
