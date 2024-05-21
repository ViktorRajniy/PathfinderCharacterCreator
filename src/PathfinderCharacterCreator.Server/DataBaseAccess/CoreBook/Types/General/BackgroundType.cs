namespace DataBaseAccess.CoreBook.Types
{
    /// <summary>
    /// Список все предысторий.
    /// </summary>
    public enum BackgroundType
    {
        /// <summary>
        /// Не выбрано.
        /// </summary>
        None = 0,

        /// <summary>
        /// Послушник.
        /// </summary>
        Acolyte,

        /// <summary>
        /// Шарлатан.
        /// </summary>
        Charlatan,

        /// <summary>
        /// Преступник.
        /// </summary>
        Criminal,

        /// <summary>
        /// Полевой доктор.
        /// </summary>
        FieldMedic,
    }
}
