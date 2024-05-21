namespace DataBaseAccess.CoreBook.Types
{
    /// <summary>
    /// Список мировоззрений персонажа.
    /// </summary>
    public enum AligmentType
    {
        /// <summary>
        /// Не выбрано.
        /// </summary>
        None = 0,

        /// <summary>
        /// Законопослушный добрый.
        /// </summary>
        LawfulGood,

        /// <summary>
        /// Нейтральный добрый.
        /// </summary>
        NeutralGood,

        /// <summary>
        /// Хаотичный добрый.
        /// </summary>
        ChaoticGood,

        /// <summary>
        /// Законопослушный нейтральный.
        /// </summary>
        LawfulNeutral,

        /// <summary>
        /// Истинно нейтральный.
        /// </summary>
        TrueNeutral,

        /// <summary>
        /// Хаотичный нейтральный.
        /// </summary>
        ChaoticNeutral,

        /// <summary>
        /// Законопослушный злой.
        /// </summary>
        LawfulEvil,

        /// <summary>
        /// Нейтральный злой.
        /// </summary>
        NeutralEvil,

        /// <summary>
        /// Хаотичный злой.
        /// </summary>
        ChaoticEvil,
    }
}
