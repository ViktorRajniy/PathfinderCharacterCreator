namespace Model
{
    using DataBaseAccess.Character;
    using Model.Editor;
    using Model.LevelManager;

    public class Character
    {
        public DBCharacter Info { get; set; }

        public ILevelManager LevelManager { get; set; }

        public ICharacterEditor Editor { get; set; }
    }
}
