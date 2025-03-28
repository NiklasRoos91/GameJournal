namespace GameJournal.DbContext
{
    public class DatabaseSeeder
    {
        private readonly GameJournalContext _context;
        private readonly GameSeeder _gameSeeder;
        private readonly ReviewSeeder _reviewSeeder;

        public DatabaseSeeder(GameJournalContext context, GameSeeder gameSeeder, ReviewSeeder reviewSeeder)
        {
            _context = context;
            _gameSeeder = gameSeeder;
            _reviewSeeder = reviewSeeder;
        }

        public void SeedDatabase()
        {
            var games = _gameSeeder.GenerateGames(10);

            _reviewSeeder.SeedReview(10);
        }
    }
}
