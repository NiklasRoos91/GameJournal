namespace GameJournal.DbContext
{
    using GameJournal.Models;
    using Microsoft.EntityFrameworkCore;

    public class GameJournalContext : DbContext
    {
        public GameJournalContext(DbContextOptions<GameJournalContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
