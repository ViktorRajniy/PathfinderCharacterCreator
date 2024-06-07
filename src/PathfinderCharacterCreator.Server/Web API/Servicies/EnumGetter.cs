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
        /// <exception cref="NotImplementedException">
        /// Нет класса в программе или допущена ошибка в строке.
        /// </exception>
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
        /// Возвращает название класса персонажа на английском.
        /// </summary>
        /// <param name="className">Тип класса.</param>
        /// <returns>Название класса на английском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет класса в программе или допущена ошибка в строке.
        /// </exception>
        public string EngClassName(ClassType className)
        {
            return className switch
            {
                ClassType.None => "None",
                ClassType.Fighter => "Fighter",
                ClassType.Wizzard => "Wizzard",
                ClassType.Alchemist => "Alchemist",
                ClassType.Champion => "Champion",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
        }

        /// <summary>
        /// Возвращает название класса персонажа на английском.
        /// </summary>
        /// <param name="className">Тип класса.</param>
        /// <returns>Название класса на английском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет класса в программе или допущена ошибка в строке.
        /// </exception>
        public string RusClassName(ClassType className)
        {
            return className switch
            {
                ClassType.None => "Не выбан",
                ClassType.Fighter => "Воин",
                ClassType.Wizzard => "Волшебник",
                ClassType.Alchemist => "Алхимик",
                ClassType.Champion => "Чемпион",
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
        /// Возвращает название подкласса персонажа на английском.
        /// </summary>
        /// <param name="className">Тип подкласса.</param>
        /// <returns>Название подкласса на английском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет класса в программе или допущена ошибка в строке.
        /// </exception>
        public string EngSubClassName(SubClassType className)
        {
            return className switch
            {
                SubClassType.None => "None",
                SubClassType.BomberAlchemist => "Bomber alchemist",
                SubClassType.MutagenistAlchemist => "Mutagenist alchemist",
                SubClassType.ChirurgeonAlchemist => "Chirurgeon alchemist",
                SubClassType.PaladinChampion => "Paladin champion",
                SubClassType.RedeemerChampion => "Redeemer champion",
                SubClassType.LiberatorChampion => "Liberator champion",
                SubClassType.StaffNexusWizzard => "Staff nexus wizzard",
                SubClassType.MetamagicalExperimentationWizzard => "Metamagical experimentation wizzard",
                SubClassType.Fighter => "Fighter",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
        }

        /// <summary>
        /// Возвращает название подкласса персонажа на русском.
        /// </summary>
        /// <param name="className">Тип подкласса.</param>
        /// <returns>Название подкласса на русском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет подкласса в программе или допущена ошибка в строке.
        /// </exception>
        public string RusSubClassName(SubClassType className)
        {
            return className switch
            {
                SubClassType.None => "Не выбан",
                SubClassType.BomberAlchemist => "Бомбометатель",
                SubClassType.MutagenistAlchemist => "Мутагенист",
                SubClassType.ChirurgeonAlchemist => "Хирург",
                SubClassType.PaladinChampion => "Паладин",
                SubClassType.RedeemerChampion => "Искупитель",
                SubClassType.LiberatorChampion => "Освободитель",
                SubClassType.StaffNexusWizzard => "Узы посоха",
                SubClassType.MetamagicalExperimentationWizzard => "Метамагическое экспериментирование",
                SubClassType.Fighter => "Воин",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
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
        /// Возвращает название родословной персонажа на английском.
        /// </summary>
        /// <param name="className">Тип родословной.</param>
        /// <returns>Название родословной на английском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет родословной в программе или допущена ошибка в строке.
        /// </exception>
        public string EngAncestoryName(AncestryType ancestry)
        {
            return ancestry switch
            {
                AncestryType.None => "None",
                AncestryType.Human => "Human",
                AncestryType.Dwarf => "Dwarf",
                AncestryType.Elf => "Elf",
                AncestryType.Goblin => "Goblin",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
        }

        /// <summary>
        /// Возвращает название родословной персонажа на русском.
        /// </summary>
        /// <param name="className">Тип родословной.</param>
        /// <returns>Название родословной на русском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет родословной в программе или допущена ошибка в строке.
        /// </exception>
        public string RusAncestoryName(AncestryType ancestry)
        {
            return ancestry switch
            {
                AncestryType.None => "Не выборан",
                AncestryType.Human => "Человек",
                AncestryType.Dwarf => "Дварф",
                AncestryType.Elf => "Эльф",
                AncestryType.Goblin => "Гоблин",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
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
        /// Возвращает название наследия персонажа на русском.
        /// </summary>
        /// <param name="haritage">Тип наследия.</param>
        /// <returns>Название наследия на английском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет наследия в программе или допущена ошибка в строке.
        /// </exception>
        public string EngHeritageName(HaritageType haritage)
        {
            return haritage switch
            {
                HaritageType.None => "None",
                HaritageType.AncientBloodedDwarf => "Ancient-blooded dwarf",
                HaritageType.DeathWardenDwarf => "Death warden dwarf",
                HaritageType.CavernElf => "Cavern elf",
                HaritageType.WoodlandElf => "Woodland elf",
                HaritageType.RazortoothGoblin => "Razortooth goblin",
                HaritageType.UnbreakableGoblin => "Unbreakable goblin",
                HaritageType.SkilledHeritage => "Skilled heritage",
                HaritageType.VersatileHeritage => "Versatile heritage",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
        }

        /// <summary>
        /// Возвращает название наследия персонажа на русском.
        /// </summary>
        /// <param name="haritage">Тип наследия.</param>
        /// <returns>Название наследия на русском.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет наследия в программе или допущена ошибка в строке.
        /// </exception>
        public string RusHeritageName(HaritageType haritage)
        {
            return haritage switch
            {
                HaritageType.None => "Не выбран",
                HaritageType.AncientBloodedDwarf => "Дварф древней крови",
                HaritageType.DeathWardenDwarf => "Дварф страж гробницы",
                HaritageType.CavernElf => "Пещерный эльф",
                HaritageType.WoodlandElf => "Лесной эльф",
                HaritageType.RazortoothGoblin => "Острозубый гоблин",
                HaritageType.UnbreakableGoblin => "Несокрушимый гоблин",
                HaritageType.SkilledHeritage => "Умелый",
                HaritageType.VersatileHeritage => "Разносторонний",
                _ => throw new NotImplementedException
                ("There is no such character Class in the program")
            };
        }

        /// <summary>
        /// Возвращает предысторию персонажа.
        /// </summary>
        /// <param name="background">Строка с названием предыстории.</param>
        /// <returns>Объект Enum предыстории персонажа.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет предыстории в программе или допущена ошибка в строке.
        /// </exception>
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
        /// Возвращает название предыстории на английском.
        /// </summary>
        /// <param name="background">Тип предыстории.</param>
        /// <returns>Строка с названием предысотрии.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет предыстории в программе или допущена ошибка в строке.
        /// </exception>
        public string EngBackgroundName(BackgroundType background)
        {
            return background switch
            {
                BackgroundType.None => "None",
                BackgroundType.Acolyte => "Acolyte",
                BackgroundType.Charlatan => "Charlatan",
                BackgroundType.Criminal => "Criminal",
                BackgroundType.FieldMedic => "FieldMedic",
                _ => throw new NotImplementedException
                ("There is no such character Background in the program")
            };

        }

        /// <summary>
        /// Возвращает название предыстории на русском.
        /// </summary>
        /// <param name="background">Тип предыстории.</param>
        /// <returns>Строка с названием предысотрии.</returns>
        /// <exception cref="NotImplementedException">
        /// Нет предыстории в программе или допущена ошибка в строке.
        /// </exception>
        public string RusBackgroundName(BackgroundType background)
        {
            return background switch
            {
                BackgroundType.None => "Не выбран",
                BackgroundType.Acolyte => "Послушник",
                BackgroundType.Charlatan => "Шарлатан",
                BackgroundType.Criminal => "Преступник",
                BackgroundType.FieldMedic => "Полевой врач",
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

        public string EngAligmentName(AligmentType aligment)
        {
            return aligment switch
            {
                AligmentType.None => "None",
                AligmentType.LawfulGood => "Lawful good",
                AligmentType.NeutralGood => "Neutral good",
                AligmentType.ChaoticGood => "Chaotic good",
                AligmentType.LawfulNeutral => "Lawful neutral",
                AligmentType.TrueNeutral => "True neutral",
                AligmentType.ChaoticNeutral => "Chaotic neutral",
                AligmentType.LawfulEvil => "Lawful evil",
                AligmentType.NeutralEvil => "Neutral evil",
                AligmentType.ChaoticEvil => "Chaotic evil",
                _ => throw new NotImplementedException
                ("There is no such character Aligment in the program")
            };
        }

        public string RusAligmentName(AligmentType aligment)
        {
            return aligment switch
            {
                AligmentType.None => "Не выбран",
                AligmentType.LawfulGood => "Законопослушный добрый",
                AligmentType.NeutralGood => "Найтральный добрый",
                AligmentType.ChaoticGood => "Хаотичный добрый",
                AligmentType.LawfulNeutral => "Законопослушный нейтральный",
                AligmentType.TrueNeutral => "Истинно нейтральный",
                AligmentType.ChaoticNeutral => "Хаотичный нейтральный",
                AligmentType.LawfulEvil => "Законопослушный злой",
                AligmentType.NeutralEvil => "Нейтральный злой",
                AligmentType.ChaoticEvil => "Хаотичный злой",
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

        public string EngDeityName(DeityType deity)
        {
            return deity switch
            {
                DeityType.Atheism => "Atheism",
                DeityType.CaydenCailean => "CaydenCailean",
                DeityType.Lamashtu => "Lamashtu",
                DeityType.Iomedae => "Iomedae",
                DeityType.ZonKuthon => "ZonKuthon",
                _ => throw new NotImplementedException
                ("There is no such character Deity in the program")
            };
        }

        public string RusDeityName(DeityType deity)
        {
            return deity switch
            {
                DeityType.Atheism => "Атеизм",
                DeityType.CaydenCailean => "Кайдэн Кайлин",
                DeityType.Lamashtu => "Ламашту",
                DeityType.Iomedae => "Айомедэй",
                DeityType.ZonKuthon => "Зон-Кутон",
                _ => throw new NotImplementedException
                ("There is no such character Deity in the program")
            };
        }

        public string RusSizeName(SizeType size)
        {
            return size switch
            {
                SizeType.Tiny => "Крошечный",
                SizeType.Small => "Маленький",
                SizeType.Medium => "Средний",
                SizeType.Huge => "Большой",
                SizeType.Large => "Огромный",
                SizeType.Gargantuan => "Исполинский",
                _ => throw new NotImplementedException
                ("There is no such character Size in the program")
            };
        }

        public string RusSkillName(SkillType skill)
        {
            return skill switch
            {
                SkillType.Acrobatics => "Акробатика",
                SkillType.Arcana => "Аркана",
                SkillType.Athletics => "Атлетика",
                SkillType.Crafting => "Ремесло",
                SkillType.Deception => "Обман",
                SkillType.Diplomacy => "Дипломатия",
                SkillType.Intimidation => "Запугивание",
                SkillType.Lore => "Знание",
                SkillType.Medicine => "Медицина",
                SkillType.Nature => "Природа",
                SkillType.Occultism => "Оккультизм",
                SkillType.Performance => "Выступление",
                SkillType.Religion => "Религия",
                SkillType.Society => "Общество",
                SkillType.Stealth => "Скрытность",
                SkillType.Survival => "Выживание",
                SkillType.Thievery => "Воровство",
                SkillType.Perception => "Внимательность",
                _ => "",
            };
        }
    }
}
