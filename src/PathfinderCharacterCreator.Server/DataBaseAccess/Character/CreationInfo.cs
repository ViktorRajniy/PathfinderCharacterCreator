namespace DataBaseAccess.Character
{
    using DataBaseAccess.CoreBook.Types;

    public class CreationInfo
    {
        /// <summary>
        /// Флаг второй свободной характеристики родословной.
        /// True - 2 свободные характеристики.
        /// False - 1 свободная характеристика.
        /// </summary>
        public bool SecondAncestoryAbility { get; set; }

        /// <summary>
        /// Список доступных для повышения характеристик родословной.
        /// Может быть пустым, в случае 2 свободных характеристик.
        /// </summary>
        public List<AbilityType>? AllowAncestoryAbility { get; set; }

        /// <summary>
        /// Флаг выбора характеристики класса.
        /// True - если нужно выбрать характеристику класса.
        /// False - если не нужно.
        /// </summary>
        public bool OptionClassAbility { get; set; }

        /// <summary>
        /// Список доступных для повышения характеристик класса.
        /// Может быть пустым, если не нужно выбирать характеристику.
        /// </summary>
        public List<AbilityType>? ClassOptionAbility { get; set; }

        /// <summary>
        /// Список доступных для повышения характеристик предыстории.
        /// </summary>
        public List<AbilityType> AllowBackgroundAbility { get; set; }

        /// <summary>
        /// Количество навыков персонажа.
        /// </summary>
        public int SkillsCount { get; set; }

        /// <summary>
        /// Количество классовых черт.
        /// </summary>
        public int ClassFeatCount { get; set; }

        /// <summary>
        /// Количество черт наследия.
        /// </summary>
        public int AncestoryFeatCount { get; set; }

        /// <summary>
        /// Количество черт навыков.
        /// </summary>
        public int SkillFeatCount { get; set; }

        /// <summary>
        /// Количество общих черт.
        /// </summary>
        public int GeneralFeatCount { get; set; }
    }
}
