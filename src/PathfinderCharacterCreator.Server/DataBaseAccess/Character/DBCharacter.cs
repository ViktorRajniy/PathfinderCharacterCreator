namespace DataBaseAccess.Character
{
    using DataBaseAccess.CoreBook.Actions;
    using DataBaseAccess.CoreBook.Feats;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("Characters")]
    public class DBCharacter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public DBUser User { get; set; }

        [Required]
        public DBGeneralInfo General { get; set; }

        [Required]
        public DBStats Stats { get; set; }

        [Required]
        public int Wallet { get; set; } = 0;

        [Required]
        public List<DBFeat> Feats { get; set; }

        [Required]
        public List<DBAction> Actions { get; set; }

        [Required]
        public List<string> ItemNames { get; set; }
    }
}
