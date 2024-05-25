using DataBaseAccess.CoreBook.Types;

namespace Web_API.Servicies
{
    /// <summary>
    /// Класс возвращающий объекты Enum соотнося их по строке.
    /// </summary>
    public class EnumGetter
    {
        /// <summary>
        /// Возвращает класс персонажа.
        /// </summary>
        /// <param name="className">Строка с названием класса.</param>
        /// <returns>Объект Enum класса персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет класса в программе 
        /// или допущена ошибка в строке.</exception>
        public ClassType Class(string className)
        {
            return className switch
            {
                "Fighter" => ClassType.Fighter,
                "Wizzard" => ClassType.Wizzard,
                "Alchemist" => ClassType.Alchemist,
                "Champion" => ClassType.Champion,
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
        }

        /// <summary>
        /// Возвращает подкласс персонажа.
        /// </summary>
        /// <param name="className">Класс персонажа.</param>
        /// <param name="subClass">Строка с названием подкласса.</param>
        /// <returns>Объект Enum подкласса персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет подкласса в программе 
        /// или допущена ошибка в строке.</exception>
        public SubClassType SubClass(ClassType className, string subClass)
        {
            switch (className)
            {
                case ClassType.Alchemist:
                    return subClass switch
                    {
                        "BomberAlchemist" => SubClassType.BomberAlchemist,
                        "MutagenistAlchemist" => SubClassType.MutagenistAlchemist,
                        "ChirurgeonAlchemist" => SubClassType.ChirurgeonAlchemist,
                        _ => throw new NotImplementedException
                ("There is no such character Subclass in the program")
                    };
                case ClassType.Champion:
                    return subClass switch
                    {
                        "PaladinChampion" => SubClassType.PaladinChampion,
                        "RedeemerChampion" => SubClassType.RedeemerChampion,
                        "LiberatorChampion" => SubClassType.LiberatorChampion,
                        _ => throw new NotImplementedException
                ("There is no such character Subclass in the program")
                    };
                case ClassType.Fighter:
                    return SubClassType.Fighter;
                case ClassType.Wizzard:
                    return subClass switch
                    {
                        "StaffNexusWizzard" => SubClassType.StaffNexusWizzard,
                        "MetamagicalExperimentationWizzard"
                        => SubClassType.MetamagicalExperimentationWizzard,
                        _ => throw new NotImplementedException
                ("There is no such character Subclass in the program")
                    };
                default:
                    throw new NotImplementedException
                ("There is no such character Subclass in the program");
            }
        }

        /// <summary>
        /// Возвращает родословную персонажа.
        /// </summary>
        /// <param name="ancestory">Строка с названием родословной.</param>
        /// <returns>Объект Enum родословной персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет родословной в программе 
        /// или допущена ошибка в строке.</exception>
        public AncestryType Ancestory(string ancestory)
        {
            return ancestory switch
            {
                "Human" => AncestryType.Human,
                "Dwarf" => AncestryType.Dwarf,
                "Elf" => AncestryType.Elf,
                "Goblin" => AncestryType.Goblin,
                _ => throw new NotImplementedException
                ("There is no such character Ancestory in the program")
            };
        }

        /// <summary>
        /// Возвращает наследие персонажа.
        /// </summary>
        /// <param name="ancestory">Родословная персонажа.</param>
        /// <param name="haritage">Строка с названием наследия.</param>
        /// <returns>Объект Enum наследия персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет наследия в программе 
        /// или допущена ошибка в строке.</exception>
        public HaritageType Haritage(AncestryType ancestory, string haritage)
        {
            switch (ancestory)
            {
                case AncestryType.Dwarf:
                    return haritage switch
                    {
                        "AncientBloodedDwarf" => HaritageType.AncientBloodedDwarf,
                        "DeathWardenDwarf" => HaritageType.DeathWardenDwarf,
                        _ => throw new NotImplementedException
                ("There is no such character Haritage in the program")
                    };
                case AncestryType.Elf:
                    return haritage switch
                    {
                        "CavernElf" => HaritageType.CavernElf,
                        "WoodlandElf" => HaritageType.WoodlandElf,
                        _ => throw new NotImplementedException
                ("There is no such character Haritage in the program")
                    };
                case AncestryType.Goblin:
                    return haritage switch
                    {
                        "RazortoothGoblin" => HaritageType.RazortoothGoblin,
                        "UnbreakableGoblin" => HaritageType.UnbreakableGoblin,
                        _ => throw new NotImplementedException
                ("There is no such character Haritage in the program")
                    };
                case AncestryType.Human:
                    return haritage switch
                    {
                        "SkilledHeritage" => HaritageType.SkilledHeritage,
                        "VersatileHeritage" => HaritageType.VersatileHeritage,
                        _ => throw new NotImplementedException
                ("There is no such character Haritage in the program")
                    };
                default:
                    throw new NotImplementedException
                ("There is no such character Haritage in the program");
            }
        }

        /// <summary>
        /// Возвращает предысторию персонажа.
        /// </summary>
        /// <param name="background">Строка с названием предыстории.</param>
        /// <returns>Объект Enum предыстории персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет предыстории в программе 
        /// или допущена ошибка в строке.</exception>
        public BackgroundType Background(string background)
        {
            return background switch
            {
                "Acolyte" => BackgroundType.Acolyte,
                "Charlatan" => BackgroundType.Charlatan,
                "Criminal" => BackgroundType.Criminal,
                "FieldMedic" => BackgroundType.FieldMedic,
                _ => throw new NotImplementedException
                ("There is no such character Background in the program")
            };
        }

        /// <summary>
        /// Возвращает мировоззрение персонажа.
        /// </summary>
        /// <param name="aligment">Строка с названием мировоззрения.</param>
        /// <returns>Объект Enum мировоззрения персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет мировоззрения в программе 
        /// или допущена ошибка в строке.</exception>
        public AligmentType Aligment(string aligment)
        {
            return aligment switch
            {
                "LawfulGood" => AligmentType.LawfulGood,
                "NeutralGood" => AligmentType.NeutralGood,
                "ChaoticGood" => AligmentType.ChaoticGood,
                "LawfulNeutral" => AligmentType.LawfulNeutral,
                "TrueNeutral" => AligmentType.TrueNeutral,
                "ChaoticNeutral" => AligmentType.ChaoticNeutral,
                "LawfulEvil" => AligmentType.LawfulEvil,
                "NeutralEvil" => AligmentType.NeutralEvil,
                "ChaoticEvil" => AligmentType.ChaoticEvil,
                _ => throw new NotImplementedException
                ("There is no such character Aligment in the program")
            };
        }

        /// <summary>
        /// Возвращает веру персонажа.
        /// </summary>
        /// <param name="deity">Строка с названием божества.</param>
        /// <returns>Объект Enum божества персонажа.</returns>
        /// <exception cref="NotImplementedException">Нет божества в программе 
        /// или допущена ошибка в строке.</exception>
        public DeityType Deity(string deity)
        {
            return deity switch
            {
                "CaydenCailean" => DeityType.CaydenCailean,
                "Lamashtu" => DeityType.Lamashtu,
                "Iomedae" => DeityType.Iomedae,
                "ZonKuthon" => DeityType.ZonKuthon,
                _ => throw new NotImplementedException
                ("There is no such character Deity in the program")
            };
        }
    }
}
