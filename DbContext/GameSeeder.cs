using Bogus;
using GameJournal.Models;
using Microsoft.EntityFrameworkCore;


namespace GameJournal.DbContext
{
    public class GameSeeder
    {
        private readonly GameJournalContext _context;
        
        public GameSeeder(GameJournalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Game> GenerateGames(int numberOfGames)
        {
            var faker = new Faker<Game>()
                .RuleFor(g => g.Title, f => f.Commerce.ProductName())
                .RuleFor(g => g.Genre, f => f.PickRandom("Action", "Adventure", "RPG", "Shooter", "Puzzle", "Strategy"))
                .RuleFor(g => g.Status, f => f.PickRandom("Not Started", "In Progress", "Completed"));

            var games = faker.Generate(numberOfGames);

            _context.Games.AddRange(games);
            _context.SaveChanges();

            return games;
        }
    }
}
