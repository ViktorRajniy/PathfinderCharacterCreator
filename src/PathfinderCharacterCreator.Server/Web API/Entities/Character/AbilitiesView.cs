namespace Web_API.Entities
{
    /// <summary>
    /// Итоговое значение характеристик персонажа.
    /// </summary>
    public class AbilitiesView
    {
        /// <summary>
        /// ID персонажа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Массив значений характеристик: Сила, Ловкость, Телосложение, 
        /// Интеллект, Мудрость, Харизма.
        /// </summary>
        public int[] Abilities { get; set; }
    }
}
