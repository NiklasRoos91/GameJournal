using Bogus;
using GameJournal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameJournal.DbContext
{
    public class ReviewSeeder
    {
        private readonly GameJournalContext _context;
        
        public ReviewSeeder(GameJournalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void SeedReview(int numberOfReviews)
        {
            var games = _context.Games.ToList();

            var faker = new Faker<Review>()
                .RuleFor(r => r.GameId, f => f.PickRandom(games).GameId) 
                .RuleFor(r => r.Grade, f => f.Random.Int(1, 5)) 
                .RuleFor(r => r.Comment, f => f.Lorem.Sentence());

            var reviews = faker.Generate(numberOfReviews);

            _context.Reviews.AddRange(reviews);
            _context.SaveChanges();
        }
    }
}
