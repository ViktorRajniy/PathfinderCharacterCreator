namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Шарлатана создаваемому персонажу.
    /// </summary>
    public class CharlatanStrategy : IBackgroundStrategy
    {
        /// <summary>
        /// Метод задаёт значения предыстории шарлатана в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetBackgroundInfo(DBCharacter character, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.General.Background = BackgroundType.Charlatan;

            character.Stats.Skills[(int)SkillType.Deception]
                = ProficientyType.Trained;

            info.AllowBackgroundAbility.Add(AbilityType.Intelligence);
            info.AllowBackgroundAbility.Add(AbilityType.Charisma);

            service.SetFeat(character, info, "Charming liar");
        }
    }
}
