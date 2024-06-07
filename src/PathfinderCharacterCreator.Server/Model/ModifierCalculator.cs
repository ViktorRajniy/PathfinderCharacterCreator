namespace Model
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    public class ModifierCalculator
    {
        public int ArmorClass(DBCharacter character)
        {
            return Modifier(character.Stats.Abilities[(int)AbilityType.Dexterity],
                            character.Stats.ArmorProficienty[(int)ArmorType.Unarmored],
                            character.Level,
                            0,
                            0);
        }

        public Dictionary<SavingThrowType, int> SavingThrowsModifiers(DBCharacter character)
        {
            var modifiers = new Dictionary<SavingThrowType, int>();

            foreach (SavingThrowType savingThrow in Enum.GetValues(typeof(SavingThrowType)))
            {
                modifiers.Add(savingThrow, Modifier(
                    character.Stats.Abilities[(int)GetSavingThrowAbility(savingThrow)],
                    character.Stats.SavingThrows[(int)savingThrow],
                    character.Level,
                    0,
                    0));
            }

            return modifiers;
        }

        public Dictionary<SkillType, int> SkillModifiers(DBCharacter character)
        {
            var modifiers = new Dictionary<SkillType, int>();

            foreach(SkillType skill in Enum.GetValues(typeof(SkillType)))
            {
                modifiers.Add(skill, Modifier(
                    character.Stats.Abilities[(int)GetSkillAbility(skill)],
                    character.Stats.Skills[(int)skill],
                    character.Level,
                    0, 
                    0));
            }

            return modifiers;
        }

        private int Modifier(int ability, ProficientyType proficienty, int level, int itemBonus, int penalty)
        {
            return AbilityModifier(ability) + ProficientyBonus(proficienty, level) + itemBonus - penalty;
        }

        private AbilityType GetSkillAbility(SkillType skill)
        {
            return skill switch
            {
                SkillType.Acrobatics => AbilityType.Dexterity,
                SkillType.Arcana => AbilityType.Intelligence,
                SkillType.Athletics => AbilityType.Strength,
                SkillType.Crafting => AbilityType.Intelligence,
                SkillType.Deception => AbilityType.Charisma,
                SkillType.Diplomacy => AbilityType.Charisma,
                SkillType.Intimidation => AbilityType.Charisma,
                SkillType.Lore => AbilityType.Intelligence,
                SkillType.Medicine => AbilityType.Wisdom,
                SkillType.Nature => AbilityType.Wisdom,
                SkillType.Occultism => AbilityType.Intelligence,
                SkillType.Performance => AbilityType.Charisma,
                SkillType.Religion => AbilityType.Wisdom,
                SkillType.Society => AbilityType.Intelligence,
                SkillType.Stealth => AbilityType.Dexterity,
                SkillType.Survival => AbilityType.Wisdom,
                SkillType.Thievery => AbilityType.Dexterity,
                SkillType.Perception => AbilityType.Wisdom,
                _ => AbilityType.Intelligence,
            };
        }

        private AbilityType GetSavingThrowAbility(SavingThrowType savingThrow)
        {
            return savingThrow switch
            {
                SavingThrowType.Fortitude => AbilityType.Constitution,
                SavingThrowType.Reflex => AbilityType.Dexterity,
                SavingThrowType.Will => AbilityType.Wisdom,
                _ => AbilityType.Intelligence,
            };
        }

        private int ProficientyBonus(ProficientyType type, int level)
        {
            return type switch
            {
                ProficientyType.Trained => 2 + level,
                ProficientyType.Expert => 4 + level,
                ProficientyType.Master => 6 + level,
                ProficientyType.Legend => 8 + level,
                _ => 0,
            };
        }

        private int AbilityModifier(int ability)
        {
            return (ability - 10) / 2;
        }
    }
}
