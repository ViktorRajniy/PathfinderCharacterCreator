namespace DataBaseAccess.CoreBook.Types
{
    /// <summary>
    /// Список всех подклассов.
    /// </summary>
    public enum SubClassType
    {
        /// <summary>
        /// Не выбрано.
        /// </summary>
        None = 0,

        /// <summary>
        /// Воин - не имеет подклассов.
        /// </summary>
        Fighter,

        /// <summary>
        /// Чемпион - Паладин.
        /// </summary>
        PaladinChampion,

        /// <summary>
        /// Чемпион - Искупитель.
        /// </summary>
        RedeemerChampion,

        /// <summary>
        /// Чемпион - Освободитель.
        /// </summary>
        LiberatorChampion,

        /// <summary>
        /// Алхимик - Бомбометатель.
        /// </summary>
        BomberAlchemist,

        /// <summary>
        /// Алхимик - Хирург.
        /// </summary>
        ChirurgeonAlchemist,

        /// <summary>
        /// Алхимик - Мутагенист.
        /// </summary>
        MutagenistAlchemist,

        /// <summary>
        /// Волшебник - Узы посоха.
        /// </summary>
        StaffNexusWizzard,

        /// <summary>
        /// Волшебник - Метамагическое экспериментирование.
        /// </summary>
        MetamagicalExperimentationWizzard,
    }
}
