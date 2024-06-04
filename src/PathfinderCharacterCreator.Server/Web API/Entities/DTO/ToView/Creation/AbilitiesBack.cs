namespace Web_API.Entities.DTO.ToView
{
    using DataBaseAccess.CoreBook.Types;

    public class AbilitiesBack
    {
        public List<int> Abilities { get; set; } = [10, 10, 10, 10, 10, 10];

        public List<AbilityType> BackgroundAbilities { get; set; }

        public List<AbilityType> ClassAbilities { get; set; }

        public List<AbilityType> AncestoryAbilities { get; set; }
    }
}
