namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Послушника создаваемому персонажу.
    /// </summary>
    public class AcolyteStrategy : IBackgroundStrategy
    {
        /// <summary>
        /// Метод задаёт значения предыстории послушника в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetBackgroundInfo(DBCharacter character, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.General.Background = BackgroundType.Acolyte;

            character.Stats.Skills[(int)SkillType.Religion]
                = ProficientyType.Trained;

            info.AllowBackgroundAbility.Add(AbilityType.Intelligence);
            info.AllowBackgroundAbility.Add(AbilityType.Wisdom);

            service.SetFeat(character, info, "Student of the canon");
        }
    }
}
