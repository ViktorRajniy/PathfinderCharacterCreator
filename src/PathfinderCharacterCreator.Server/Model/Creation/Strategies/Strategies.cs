namespace Model.Creation.Strategies
{
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Структура данных, хранящая в себе словарь:
    /// Класс - Стратегия.
    /// </summary>
    public class Strategies
    {
        /// <summary>
        /// Словарь Класс - Стратегия класса.
        /// </summary>
        public Dictionary<ClassType, IClassStrategy> Class = new()
            {
                {ClassType.Fighter, new FighterStrutegy() },
                {ClassType.Wizzard, new WizzardStrutegy() },
                {ClassType.Alchemist, new AlchemistStrategy() },
                {ClassType.Champion, new ChampionStrategy() },
            };

        /// <summary>
        /// Словарь Родословная - Стратегия родословной.
        /// </summary>
        public Dictionary<AncestryType, IAncestriesStrategy> Ancestory = new()
            {
                {AncestryType.Human, new HumanStrategy() },
                {AncestryType.Elf, new ElfStrategy() },
                {AncestryType.Dwarf, new DwarfStrategy() },
                {AncestryType.Goblin, new GoblinStrategy() },
            };

        /// <summary>
        /// Словарь Предыстория - Стратегия предыстории.
        /// </summary>
        public Dictionary<BackgroundType, IBackgroundStrategy> Background = new()
            {
                {BackgroundType.Criminal, new CriminalStrategy() },
                {BackgroundType.Charlatan, new CharlatanStrategy() },
                {BackgroundType.Acolyte, new AcolyteStrategy() },
                {BackgroundType.FieldMedic, new FieldMedicStrategy() },
            };
    }
}
