namespace DataBaseAccess
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using DataBaseAccess.Character;

    /// <summary>
    /// Структура описывающая пользователя в базе данных.
    /// </summary>
    [Table("Users")]
    public class DBUser
    {
        /// <summary>
        /// ID пользователя.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Список персонажей пользователя.
        /// </summary>
        public List<DBCharacter>? CharacterList { get; set; }
    }
}
