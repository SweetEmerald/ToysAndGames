using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Data
{
    public class ToysAndGamesDbContext: DbContext
    {
        #region Models 

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        #endregion Models

        public ToysAndGamesDbContext(DbContextOptions<ToysAndGamesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
