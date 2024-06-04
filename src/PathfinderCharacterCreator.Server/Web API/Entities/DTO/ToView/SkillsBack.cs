namespace Web_API.Entities.DTO
{
    using DataBaseAccess.CoreBook.Types;

    public class SkillsBack
    {
        public int SkillCount { get; set; } = 0;

        public List<SkillType> AllowedSkillsList { get; set; } = new List<SkillType>() { };
    }
}
