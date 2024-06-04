namespace Web_API.Entities.DTO
{
    /// <summary>
    /// Значение названий черт, приходящее со View.
    /// </summary>
    public class FeatsView
    {
        /// <summary>
        /// ID персонажа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Массив названий черт.
        /// </summary>
        public string[] Feats { get; set; } = new string[] { };
    }
}
