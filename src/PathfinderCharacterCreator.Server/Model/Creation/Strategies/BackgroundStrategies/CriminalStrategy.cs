namespace Model.Creation.Strategies
{ 
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Преступника создаваемому персонажу.
    /// </summary>
    public class CriminalStrategy : IBackgroundStrategy
    {
        /// <summary>
        /// Метод задаёт значения предыстории преступника в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetBackgroundInfo(DBCharacter character, CreationInfo info)
        {
            var service = new CreationGeneralInfoService();

            character.General.Background = BackgroundType.Criminal;

            character.Stats.Skills[(int)SkillType.Stealth]
                = ProficientyType.Trained;

            info.AllowBackgroundAbility.Add(AbilityType.Dexterity);
            info.AllowBackgroundAbility.Add(AbilityType.Intelligence);

            service.SetFeat(character, info, "Experienced smuggler");
        }
    }
}
