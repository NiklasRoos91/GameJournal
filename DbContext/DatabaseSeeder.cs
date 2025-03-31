namespace GameJournal.DbContext
{
    public class DatabaseSeeder
    {
        private readonly GameJournalContext _context;
        private readonly GameSeeder _gameSeeder;
        private readonly ReviewSeeder _reviewSeeder;

        public DatabaseSeeder(GameJournalContext context, GameSeeder gameSeeder, ReviewSeeder reviewSeeder)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _gameSeeder = gameSeeder ?? throw new ArgumentNullException(nameof(gameSeeder));
            _reviewSeeder = reviewSeeder ?? throw new ArgumentNullException(nameof(reviewSeeder));
        }

        public void SeedDatabase()
        {
            var games = _gameSeeder.GenerateGames(1);

            _reviewSeeder.SeedReview(1);
        }
    }
}
