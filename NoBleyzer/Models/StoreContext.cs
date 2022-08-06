using Microsoft.EntityFrameworkCore;

namespace NoBleyzer.Models
{
    public class StoreContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PC> PCs { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
