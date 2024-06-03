namespace Model.Creation.Strategies
{
    using DataBaseAccess.Character;
    using DataBaseAccess.CoreBook.Types;

    /// <summary>
    /// Класс задающий значения Полевого врача создаваемому персонажу.
    /// </summary>
    public class FieldMedicStrategy : IBackgroundStrategy
    {
        /// <summary>
        /// Метод задаёт значения предыстории полевого врача в создаваемого персонажа.
        /// </summary>
        /// <param name="character">Изменяемый персонаж.</param>
        public void SetBackgroundInfo(DBCharacter character)
        {
            var service = new CreationGeneralInfoService();

            character.General.Background = BackgroundType.FieldMedic;

            character.Stats.Skills[(int)SkillType.Medicine]
                = ProficientyType.Trained;

            character.CreationInfo.BackgroundAbility.Add(AbilityType.Constitution);
            character.CreationInfo.BackgroundAbility.Add(AbilityType.Wisdom);

            service.SetFeat(character, "Battle medicine");
        }
    }
}
