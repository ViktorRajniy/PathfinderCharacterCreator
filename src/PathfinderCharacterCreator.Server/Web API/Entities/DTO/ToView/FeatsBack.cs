using DataBaseAccess.CoreBook.Feats;

namespace Web_API.Entities.DTO
{
    public class FeatsBack
    {
        public int ClassFeatCount { get; set; } = 0;

        public int AncestryFeatCount { get; set; } = 0;

        public int GeneralFeatCount { get; set; } = 0;

        public int SkillFeatCount { get; set; } = 0;

        public List<DBFeat> AllowedFeats { get; set; } = new List<DBFeat>() { };
    }
}
