namespace Web_API.Entities.DTO
{
    /// <summary>
    /// Значение навыков, приходящее со View.
    /// </summary>
    public class SkillsView
    {
        /// <summary>
        /// ID персонажа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Массив значений изученности навыков.
        /// Акробатика, Мистика, Атлетика, Ремесло, Обман, Дипломатия, Запугивание,
        /// Знание, Медицина, Природа, Оккультизм, Выступление, Религия, Общество,
        /// Скрытность, Выживание, Внимательность.
        /// </summary>
        public int[] Skills { get; set; } = new int[18];
    }
}
