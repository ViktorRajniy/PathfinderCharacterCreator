namespace DataBaseAccess
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        #region DbSet

        #endregion

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
